using Doctors.Domain.Entities;
using Doctors.Domain.Utils;

namespace Doctors.Application.Queries.ListDataSheet
{
    public class ListDataSheetResponse : CommandResponse
    {
        public DoctorDto Doctor { get; set; }
        public List<Response> DoctorDataSheets { get; set; }
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }

        public class Response
        {
            public PacientDto Pacient { get; set; }
            public string Details { get; set; }
            public bool DataSheetActive { get; set; }
        }
    }

    public class DoctorDto
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Crm { get; set; }
        public string Specialty { get; set; }
        public bool Active { get; set; } = true;
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