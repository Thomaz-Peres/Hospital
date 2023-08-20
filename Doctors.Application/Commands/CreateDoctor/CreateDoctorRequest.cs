using MediatR;

namespace Doctors.Application.Commands.CreateDoctor
{
    public class CreateDoctorRequest : IRequest<CreateDoctorResponse>
    {
        public required string Name { get; set; }

        public required string Cpf { get; set; }

        public required string Crm { get; set; }

        public required string Specialty { get; set; }
        public required string Password { get; set; }
        public bool Active { get; set; } = true;
    }
}
