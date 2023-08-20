using System.Text.Json.Serialization;
using Doctors.Domain.Utils;
using MediatR;

namespace Doctors.Application.Commands.CreateDataSheet
{
    public class CreateDataSheetRequest : IRequest<CreateDataSheetResponse>
    {
        public string Details { get; set; }
        public string[] PacientImage { get; set; }
        public PacientDto Pacient { get; set; }
        [JsonIgnore]
        public string DoctorIdentifier { get; set; }
    }

    public class PacientDto
    {
        public string Name { get; set; }
        public string CellphoneNumber { get; set; }
        public Address Address { get; set; }
        public string Cpf { get; set; }
        public bool Active { get; set; } = true;
    }
}