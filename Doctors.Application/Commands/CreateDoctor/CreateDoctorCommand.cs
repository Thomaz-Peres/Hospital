using Doctors.Domain.Entities;
using Doctors.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Doctors.Application.Commands.CreateDoctor
{
    public class CreateDoctorCommand : IRequestHandler<CreateDoctorRequest, CreateDoctorResponse>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<UserRole> _roleManager;
        private readonly IMediator _mediator;
        public CreateDoctorCommand(IDoctorRepository doctorRepository, IMediator mediator, IUserRepository userRepository, UserManager<User> userManager, RoleManager<UserRole> roleManager)
        {
            _doctorRepository = doctorRepository;
            _mediator = mediator;
            _userRepository = userRepository;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<CreateDoctorResponse> Handle(CreateDoctorRequest request, CancellationToken cancellationToken)
        {
            var existentUser = _userRepository.FindAsync(x => x.UserName == request.Crm)?.Result;
            if (existentUser != null)
                return new CreateDoctorResponse { Success = false, Message = "Doctor already exists" };

            if (existentUser != null && !existentUser.Active)
                return new CreateDoctorResponse { Success = false, Message = "Doctor is inactive" };

            User user = new(request.Crm);

            var result = await _userManager.CreateAsync(user, request.Password);
            user = await _userManager.FindByNameAsync(user.UserName);
            var userRole = await _userManager.AddToRoleAsync(user, "Doctor");

            Doctor doctor = new()
            {
                Name = request.Name,
                Cpf = request.Cpf,
                Crm = request.Crm,
                Specialty = request.Specialty,
                UserIdentifier = user.Id
            };
            await _doctorRepository.AddAsync(doctor);

            return new CreateDoctorResponse { Name = doctor.Name, Success = true, Message = "Doctor login created" };
        }
    }
}
