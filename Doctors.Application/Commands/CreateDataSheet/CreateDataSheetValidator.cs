using Doctors.Domain.Utils;
using FluentValidation;

namespace Doctors.Application.Commands.CreateDataSheet
{
    public class CreateDataSheetValidator : AbstractValidator<CreateDataSheetRequest>
    {
        public CreateDataSheetValidator()
        {
            RuleFor(x => x.Pacient.Cpf).NotEmpty().Must(BeAValidIdentity).WithMessage("Pacient cpf is not valid");
            RuleFor(x => x.Pacient.CellphoneNumber).NotEmpty().Must(BeAValidCellphoneNumber).WithMessage("Pacient phone number is not valid");
            RuleFor(x => x.Pacient.Name).NotEmpty();
        }
        private bool BeAValidIdentity(string identity) =>
            !string.IsNullOrEmpty(identity) && identity.IsValidCpf();

        private bool BeAValidCellphoneNumber(string identity) =>
            !string.IsNullOrEmpty(identity) && identity.IsValidPhoneNumber();
    }
}
