using Doctors.Domain.Entities;
using Doctors.Domain.Interfaces;
using MediatR;

namespace Doctors.Application.Commands.CreateDoctor
{
    public class CreateDoctorCommand : IRequestHandler<CreateDoctorRequest, CreateDoctorResponse>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMediator _mediator;
        public CreateDoctorCommand(IDoctorRepository doctorRepository, IMediator mediator)
        {
            _doctorRepository = doctorRepository;
            _mediator = mediator;
        }

        public async Task<CreateDoctorResponse> Handle(CreateDoctorRequest request, CancellationToken cancellationToken)
        {
            var existentDoctor = _doctorRepository.FindAsync(x => x.Crm == request.Crm)?.Result;
            if (existentDoctor != null)
                return new CreateDoctorResponse { Success = false, Message = "Doctor already exists" };

            if (existentDoctor != null && !existentDoctor.Active)
                return new CreateDoctorResponse { Success = false, Message = "Doctor is inactive" };

            Doctor doctor = new()
            {
                Name = request.Name,
                Cpf = request.Cpf,
                Crm = request.Crm,
                Specialty = request.Specialty,
            };

            await _doctorRepository.AddAsync(doctor);

            return new CreateDoctorResponse { Name = doctor.Name, Success = true, Message = "Doctor saved" };
        }
    }
}
