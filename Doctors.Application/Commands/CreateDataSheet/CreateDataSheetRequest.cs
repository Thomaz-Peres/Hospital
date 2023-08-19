using Doctors.Domain.Entities;
using Doctors.Domain.Utils;
using MediatR;

namespace Doctors.Application.Commands.CreateDataSheet
{
    public class CreateDataSheetRequest : IRequest<CreateDataSheetResponse>
    {
        public int DataSheetId { get; set; }
        public required string PacientName { get; set; }
        public required string  PacientCpf { get; set; }
        public required string  CellphoneNumber { get; set; }
        public virtual Address? Address { get; set; }
        public string? Details { get; set; }
        public required Pacient Pacient { get; set; }
        public required Doctor Doctor { get; set; }
    }
}