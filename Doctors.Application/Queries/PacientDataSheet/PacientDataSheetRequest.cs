using System.Text.Json.Serialization;
using MediatR;

namespace Doctors.Application.Queries.PacientDataSheet
{
    public class PacientDataSheetRequest : IRequest<PacientDataSheetResponse>
    {
        [JsonIgnore]
        public required int DataSheetId { get; set; }
        [JsonIgnore]
        public required string Cpf { get; set; }
    }
}