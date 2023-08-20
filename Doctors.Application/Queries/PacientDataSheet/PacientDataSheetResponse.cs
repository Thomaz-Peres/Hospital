using Doctors.Application.Queries.ListDataSheet;

namespace Doctors.Application.Queries.PacientDataSheet
{
    public class PacientDataSheetResponse : CommandResponse
    {
        public Response DataSheet { get; set; }

        public class Response
        {
            public DoctorDto Doctor { get; set; }
            public PacientDto Pacient { get; set; }
            public string Details { get; set; }
        }
    }
}