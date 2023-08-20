using Doctors.Domain.Utils;
using FluentValidation;

namespace Doctors.Application.Queries.PacientDataSheet
{
    public class PacientDataSheetValidator : AbstractValidator<PacientDataSheetRequest>
    {
        public PacientDataSheetValidator()
        {
            RuleFor(x => x.Cpf).NotEmpty().Must(BeAValidIdentity).WithMessage("Cpf is not valid");
            RuleFor(x => x.DataSheetId).NotEmpty();
        }

        private bool BeAValidIdentity(string identity) =>
            !string.IsNullOrEmpty(identity) && identity.IsValidCpf();
    }
}