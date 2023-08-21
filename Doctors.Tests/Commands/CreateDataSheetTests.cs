using System.Linq.Expressions;
using Doctors.Application.Commands.CreateDataSheet;
using Doctors.Domain.Interfaces;
using FluentValidation.TestHelper;
using MediatR;
using Moq;

namespace Doctors.Tests.Commands
{
    public class CreateDataSheetTests
    {
        private readonly Mock<CreateDataSheetCommand> _dataSheetCommand;
        private readonly CreateDataSheetRequest? _dataSheetRequest;
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IDoctorRepository> _doctorRepository;
        private readonly Mock<IDataSheetRepository> _dataSheetRepository;
        private readonly CreateDataSheetValidator _validator;
        public CreateDataSheetTests()
        {
            _dataSheetCommand = new();
            _mediator = new Mock<IMediator>();
            _doctorRepository = new();
            _dataSheetRepository = new();
            _validator = new();

            _dataSheetCommand = new(
                _dataSheetRepository.Object,
                _doctorRepository.Object,
                _mediator.Object);

            _dataSheetRequest = new()
            {
                Pacient = new()
                {
                    Cpf = "202.381.810-90",
                    Name = Faker.Name.FullName(),
                    CellphoneNumber = "+5567997137377",
                }
            };
        }

        [Fact]
        [Trait("Success", "CreateDataSheet")]
        public async Task Should_Create_Data_Sheet()
        {
            var doctor = new Doctor()
            {
                Name = Faker.Name.FullName(),
                Cpf = "202.381.810-90",
                Crm = "1234",
                UserIdentifier = new Guid("a73690c2-61d7-4663-a814-1c4cc1be1737").ToString(),
                Specialty = "pediatra"
            };
            _doctorRepository.Setup(x => x.FindAsync(It.IsAny<Expression<Func<Doctor, bool>>>(),
                                            It.IsAny<Expression<Func<Doctor, object>>[]>()))
                                            .ReturnsAsync(doctor);

            var result = await _dataSheetCommand.Object.Handle(_dataSheetRequest, new CancellationToken());

            Assert.True(result.Success);
            Assert.IsType<CreateDataSheetResponse>(result);
        }

        [Fact]
        [Trait("Fail", "CpfError")]
        public async Task Should_Error_Cpf_Pacient()
        {
            var doctor = new Doctor()
            {
                Name = Faker.Name.FullName(),
                Cpf = "202.381.810-90",
                Crm = "1234",
                UserIdentifier = new Guid("a73690c2-61d7-4663-a814-1c4cc1be1737").ToString(),
                Specialty = "pediatra"
            };

            _dataSheetRequest.Pacient.Cpf = "12345667";

            var result = _validator.TestValidate(_dataSheetRequest);

            Assert.False(result.IsValid);
        }

        [Fact]
        [Trait("Fail", "DoctorNotFound")]
        public async Task Should_Error_Doctor_Not_Found()
        {
            _doctorRepository.Setup(x => x.FindAsync(It.IsAny<Expression<Func<Doctor, bool>>>(),
                                            It.IsAny<Expression<Func<Doctor, object>>[]>()));

            var result = await _dataSheetCommand.Object.Handle(_dataSheetRequest, new CancellationToken());

            Assert.False(result.Success);
            Assert.IsType<CreateDataSheetResponse>(result);
        }
    }
}