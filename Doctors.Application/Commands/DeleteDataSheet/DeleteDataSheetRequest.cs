using System.Text.Json.Serialization;
using MediatR;

namespace Doctors.Application.Commands.DeleteDataSheet
{
    public class DeleteDataSheetRequest : IRequest<DeleteDataSheetResponse>
    {
        [JsonIgnore]
        public required int DataSheedId { get; set; }
        [JsonIgnore]
        public string DoctorIdentifier { get; set; }
    }
}