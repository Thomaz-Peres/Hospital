using System.ComponentModel.DataAnnotations;

namespace Doctors.Domain.Entities
{
    public class Pacient
    {
        [Key]
        public int PacientId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(255, ErrorMessage = "Must contain a maximum of 255 characters")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "CPF is required")]
        public required string Cpf { get; set; }
        public virtual List<DataSheet>? DataSheets { get; set; }
        public bool Active { get; set; } = true;
    }
}
