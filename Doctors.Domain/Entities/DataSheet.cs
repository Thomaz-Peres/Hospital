using Doctors.Domain.Utils;

namespace Doctors.Domain.Entities
{
    public class DataSheet
    {
        public required string PacientName { get; set; }
        public required string  PacientCpf { get; set; }
        public required string  CellphoneNumber { get; set; }
        public Address? Address { get; set; }
        public string? Details { get; set; }
        public required virtual Pacient Pacient { get; set; }
        public required virtual Doctor Doctor { get; set; }
        public bool Active { get; set; } = true;
    }
}