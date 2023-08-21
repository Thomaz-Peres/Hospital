using System.Linq.Expressions;
using Doctors.Application.Commands.UpdateDataSheet;
using Doctors.Domain.Interfaces;
using MediatR;
using Moq;

namespace Doctors.Tests.Commands
{
    public class UpdateDataSheetTests
    {
        private readonly Mock<UpdateDataSheetCommand> _dataSheetCommand;
        private readonly UpdateDataSheetRequest? _dataSheetRequest;
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IDataSheetRepository> _dataSheetRepository;
        public UpdateDataSheetTests()
        {
            _dataSheetCommand = new();
            _mediator = new Mock<IMediator>();
            _dataSheetRepository = new();

            _dataSheetCommand = new(
                _dataSheetRepository.Object,
                _mediator.Object);

            _dataSheetRequest = new()
            {
                DataSheetId = 1,
                Details = "unit test",
                DoctorIdentifier = new Guid("a73690c2-61d7-4663-a814-1c4cc1be1737").ToString(),
                Pacient = new()
                {
                    Cpf = "202.381.810-90",
                    Name = Faker.Name.FullName(),
                    CellphoneNumber = "+5567997137377",
                }
            };
        }

        [Fact]
        [Trait("Success", "UpdateDataSheet")]
        public async Task Should_Update_Data_Sheet()
        {
            var doctor = new Doctor()
            {
                DoctorId = 1,
                Name = Faker.Name.FullName(),
                Cpf = "202.381.810-90",
                Crm = "1234",
                UserIdentifier = new Guid("a73690c2-61d7-4663-a814-1c4cc1be1737").ToString(),
                Specialty = "pediatra"
            };

            var dataSheet = new DataSheet()
            {
                DataSheetId = 1,
                Doctor = doctor,
                Pacient = new()
                {
                    Cpf = "202.381.810-90",
                    Name = Faker.Name.FullName(),
                    CellphoneNumber = "+5567997137377",
                    PacientId = 1,
                },
            };

            _dataSheetRepository.Setup(x => x.FindAsync(It.IsAny<Expression<Func<DataSheet, bool>>>(),
                                            It.IsAny<Expression<Func<DataSheet, object>>[]>()))
                                            .ReturnsAsync(dataSheet);

            var result = await _dataSheetCommand.Object.Handle(_dataSheetRequest, new CancellationToken());

            Assert.True(result.Success);
            Assert.IsType<UpdateDataSheetResponse>(result);
        }

        [Fact]
        [Trait("Fail", "DoctorNotFound")]
        public async Task Should_Error_Doctor_Not_Found()
        {
            _dataSheetRepository.Setup(x => x.FindAsync(It.IsAny<Expression<Func<DataSheet, bool>>>(),
                                            It.IsAny<Expression<Func<DataSheet, object>>[]>()));

            var result = await _dataSheetCommand.Object.Handle(_dataSheetRequest, new CancellationToken());

            Assert.False(result.Success);
            Assert.IsType<UpdateDataSheetResponse>(result);
        }
    }
}