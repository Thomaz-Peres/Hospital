using System.ComponentModel.DataAnnotations;

namespace Doctors.Domain.Entities
{
    public class DataSheet
    {
        [Key]
        public int DataSheetId { get; set; }
        public string? Details { get; set; }
        public required virtual Pacient Pacient { get; set; }
        public required virtual Doctor Doctor { get; set; }
        public bool Active { get; set; } = true;
    }
}