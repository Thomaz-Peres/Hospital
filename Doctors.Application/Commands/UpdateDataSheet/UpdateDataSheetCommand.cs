using System.Collections.ObjectModel;
using Doctors.Domain.Entities;
using Doctors.Domain.Interfaces;
using MediatR;

namespace Doctors.Application.Commands.UpdateDataSheet
{
    public class UpdateDataSheetCommand : IRequestHandler<UpdateDataSheetRequest, UpdateDataSheetResponse>
    {
        private readonly IDataSheetRepository _dataSheetRepository;
        private readonly IMediator _mediator;

        public UpdateDataSheetCommand(IDataSheetRepository dataSheetRepository, IMediator mediator)
        {
            _dataSheetRepository = dataSheetRepository;
            _mediator = mediator;
        }

        public async Task<UpdateDataSheetResponse> Handle(UpdateDataSheetRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
                return new UpdateDataSheetResponse() { Success = false, Message = "Request is empty" };

            var dataSheet = await _dataSheetRepository.FindAsync(x => x.DataSheetId == request.DataSheetId && x.Doctor.UserIdentifier == request.DoctorIdentifier, c => c.Pacient, c => c.Pacient.Address, d => d.Doctor);

            if (dataSheet is not null)
            {
                dataSheet.Details = request.Details;

                Pacient pacient = new()
                {
                    Name = request?.Pacient?.Name,
                    CellphoneNumber = request?.Pacient?.CellphoneNumber,
                    Cpf = dataSheet?.Pacient?.Cpf,
                    Address = request?.Pacient?.Address,
                };
                dataSheet.Pacient = pacient;

                await _dataSheetRepository.UpdateAsync(dataSheet);

                return new UpdateDataSheetResponse() { Success = true, Message = "Data Sheet updated" };
            }

            return new UpdateDataSheetResponse() { Success = false, Message = "Fail to update Data Sheet" };
        }
    }
}