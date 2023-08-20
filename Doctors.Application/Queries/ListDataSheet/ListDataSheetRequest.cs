using System.Text.Json.Serialization;
using MediatR;

namespace Doctors.Application.Queries.ListDataSheet
{
    public class ListDataSheetRequest : IRequest<ListDataSheetResponse>
    {
        public int Page { get; set; }
        public int ItemsPerPage { get; set; } = 10;
        [JsonIgnore]
        public string DoctorIdentifier { get; set; }
    }
}