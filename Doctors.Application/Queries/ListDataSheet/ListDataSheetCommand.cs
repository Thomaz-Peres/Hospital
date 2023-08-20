using Doctors.Domain.Entities;
using Doctors.Domain.Interfaces;
using MediatR;

namespace Doctors.Application.Queries.ListDataSheet
{
    public class ListDataSheetCommand : IRequestHandler<ListDataSheetRequest, ListDataSheetResponse>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IDataSheetRepository _dataSheetRepository;
        private readonly IMediator _mediator;
        public ListDataSheetCommand(IMediator mediator, IDoctorRepository doctorRepository, IDataSheetRepository dataSheetRepository)
        {
            _mediator = mediator;
            _doctorRepository = doctorRepository;
            _dataSheetRepository = dataSheetRepository;
        }

        public async Task<ListDataSheetResponse> Handle(ListDataSheetRequest request, CancellationToken cancellationToken)
        {
            var doctorDataSheets = await _dataSheetRepository.GetAllAsync(x => x.Doctor.UserIdentifier == request.DoctorIdentifier, z => z.Pacient, z => z.Doctor);
            if (doctorDataSheets == null)
                return new ListDataSheetResponse() { Success = false, Message = "Data Sheets not found" };


            List<ListDataSheetResponse.Response> dataSheets = new();
            var doctor = doctorDataSheets.FirstOrDefault(x => x.Doctor != null);
            foreach (var dataSheet in doctorDataSheets)
            {
                dataSheets.Add(new ListDataSheetResponse.Response
                {
                    Pacient = new()
                    {
                        Name = dataSheet?.Pacient?.Name,
                        Cpf = dataSheet?.Pacient?.Cpf,
                        Address = dataSheet?.Pacient?.Address,
                        CellphoneNumber = dataSheet?.Pacient?.CellphoneNumber,
                        Active = dataSheet.Pacient.Active,
                    },
                    Details = dataSheet?.Details,
                    DataSheetActive = dataSheet.Active,
                });
            }

            var item = dataSheets.Skip((request.Page - 1) * request.ItemsPerPage).Take(request.ItemsPerPage).ToList();
            var total = item.Count;
            var next = dataSheets.Skip(request.Page * request.ItemsPerPage).Any();

            return new ListDataSheetResponse()
            {
                Doctor = new()
                {
                    Name = doctor?.Doctor?.Name,
                    Cpf = doctor?.Doctor?.Cpf,
                    Crm = doctor?.Doctor?.Crm,
                    Specialty = doctor?.Doctor?.Specialty,
                    Active = doctor.Doctor.Active,
                },
                Success = true,
                DoctorDataSheets = item,
                ItemsPerPage = request.ItemsPerPage,
                TotalItems = total,
            };
        }
    }
}