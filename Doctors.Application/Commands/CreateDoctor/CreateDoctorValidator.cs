using Doctors.Domain.Utils;
using FluentValidation;

namespace Doctors.Application.Commands.CreateDoctor
{
    public class CreateDoctorValidator : AbstractValidator<CreateDoctorRequest>
    {
        public CreateDoctorValidator()
        {
            RuleFor(x => x.Crm).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Specialty).NotEmpty();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(5);
            RuleFor(x => x.Cpf).NotEmpty().Must(BeAValidIdentity).WithMessage("Cpf not valid");
        }

        private bool BeAValidIdentity(string identity) =>
            !string.IsNullOrEmpty(identity) && identity.IsValidCpf();
    }
}
