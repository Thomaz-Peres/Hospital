using Doctors.Domain.Interfaces;
using MediatR;

namespace Doctors.Application.Commands.DeleteDataSheet
{
    public class DeleteDataSheetCommand : IRequestHandler<DeleteDataSheetRequest, DeleteDataSheetResponse>
    {
        private readonly IDataSheetRepository _dataSheetRepository;
        private readonly IMediator _mediator;

        public DeleteDataSheetCommand(IDataSheetRepository dataSheetRepository,
                IMediator mediator)
        {
            _dataSheetRepository = dataSheetRepository;
            _mediator = mediator;
        }

        public async Task<DeleteDataSheetResponse> Handle(DeleteDataSheetRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new DeleteDataSheetResponse() { Success = false, Message = "Request empty" };

            var dataSheet = await _dataSheetRepository.FindAsync(x => x.DataSheetId == request.DataSheedId && x.Doctor.UserIdentifier == request.DoctorIdentifier, z => z.Doctor);

            if (dataSheet is not null)
            {
                dataSheet.Active = false;

                await _dataSheetRepository.UpdateAsync(dataSheet);

                return new DeleteDataSheetResponse() { Success = true, Message = "Data Sheet excluded" };
            }

            return new DeleteDataSheetResponse() { Success = false, Message = "Data Sheet not found" };
        }
    }
}