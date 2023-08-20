using System.Text.Json.Serialization;
using Doctors.Application.Commands.CreateDataSheet;
using Doctors.Domain.Utils;
using MediatR;

namespace Doctors.Application.Commands.UpdateDataSheet
{
    public class UpdateDataSheetRequest : IRequest<UpdateDataSheetResponse>
    {
        [JsonIgnore]
        public required int DataSheetId { get; set; }
        public string Details { get; set; }
        public PacientDto Pacient { get; set; }
        [JsonIgnore]
        public string DoctorIdentifier { get; set; }
    }
}