using Doctors.Domain.Utils;

namespace Doctors.Application.Utils
{
    public class PacientDto
    {
        public string Name { get; set; }
        public string CellphoneNumber { get; set; }
        public Address Address { get; set; }
        public string Cpf { get; set; }
        public bool Active { get; set; } = true;
    }
}