using System.Linq.Expressions;
using Doctors.Application.Commands.CreateDoctor;
using Doctors.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace Doctors.Tests.Commands
{
    public class CreateDoctorTests
    {
        private readonly Mock<CreateDoctorCommand> _doctorCommand;
        private readonly CreateDoctorRequest? _doctorRequest;
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IDoctorRepository> _doctorRepository;
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<UserManager<User>> _userManager;
        private readonly Mock<RoleManager<UserRole>> _userRoleManager;
        public CreateDoctorTests()
        {
            _doctorCommand = new Mock<CreateDoctorCommand>();
            _mediator = new Mock<IMediator>();
            _doctorRepository = new();
            _userRepository = new();
            _userManager = new Mock<UserManager<User>>(Mock.Of<IUserStore<User>>());
            _userRoleManager = new Mock<RoleManager<UserRole>>(Mock.Of<IRoleStore<UserRole>>());

            _doctorCommand = new(
                _doctorRepository.Object,
                _mediator.Object,
                _userRepository.Object,
                _userManager.Object,
                _userRoleManager.Object);

            _doctorRequest = new()
            {
                Name = Faker.Name.FullName(),
                Cpf = "",
                Crm = "123",
                Password = "123456",
                Specialty = "pediatrician"
            };
        }

        [Fact(Skip = "error with user and role managers")]
        [Trait("CreateDoctorSuccess", "CreateDoctor")]
        public async Task Should_Create_Doctor()
        {
            // var doctor = new Doctor()
            // {
            //     Name = Faker.Name.FullName(),
            //     Cpf = "202.381.810-90",

            // };
            _doctorRepository.Setup(x => x.FindAsync(It.IsAny<Expression<Func<Doctor, bool>>>(),
                                            It.IsAny<Expression<Func<Doctor, object>>[]>()));
            
            var result = await _doctorCommand.Object.Handle(_doctorRequest, new CancellationToken());

            Assert.True(result.Success);
            Assert.IsType<CreateDoctorResponse>(result);
        }
    }
}