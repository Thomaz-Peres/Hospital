using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doctors.Domain.Entities
{
    public class DataSheet
    {
        [Key]
        public int DataSheetId { get; set; }
        public string? Details { get; set; }
        public virtual Pacient Pacient { get; set; }
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public bool Active { get; set; } = true;
    }
}