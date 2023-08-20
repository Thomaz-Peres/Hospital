using Doctors.Domain.Interfaces;
using MediatR;

namespace Doctors.Application.Queries.PacientDataSheet
{
    public class PacientDataSheetCommand : IRequestHandler<PacientDataSheetRequest, PacientDataSheetResponse>
    {
        private readonly IMediator _mediator;
        private readonly IDataSheetRepository _dataSheetRepository;
        public PacientDataSheetCommand(IMediator mediator, IPacientRepository pacientRepository, IDataSheetRepository dataSheetRepository)
        {
            _mediator = mediator;
            _dataSheetRepository = dataSheetRepository;
        }
        public async Task<PacientDataSheetResponse> Handle(PacientDataSheetRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new PacientDataSheetResponse() { Success = false, Message = "Request empty "};

            var pacientDataSheet = await _dataSheetRepository.FindAsync(x => x.Pacient.Cpf == request.Cpf && x.DataSheetId == request.DataSheetId, z => z.Doctor, z => z.Pacient);
            if (pacientDataSheet != null)
            {
                PacientDataSheetResponse.Response response = new()
                {
                    Doctor = new()
                    {
                        Name = pacientDataSheet.Doctor.Name,
                        Cpf = pacientDataSheet.Doctor.Cpf,
                        Crm = pacientDataSheet.Doctor.Crm,
                        Active = pacientDataSheet.Doctor.Active,
                        Specialty = pacientDataSheet.Doctor.Specialty,
                    },
                    Details = pacientDataSheet.Details,
                    Pacient = new()
                    {
                        Name = pacientDataSheet.Pacient.Name,
                        Cpf = pacientDataSheet.Pacient.Cpf,
                        Address = pacientDataSheet.Pacient?.Address,
                        CellphoneNumber = pacientDataSheet.Pacient.CellphoneNumber,
                    }
                };
                return new PacientDataSheetResponse() { Success = true, DataSheet = response };
            }

            return new PacientDataSheetResponse() { Success = false, Message = "Date Sheet not found "};
        }
    }
}