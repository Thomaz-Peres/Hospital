using System.Text.RegularExpressions;
using Doctors.Domain.Entities;
using Doctors.Domain.Interfaces;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Http;

namespace Doctors.Application.Commands.CreateDataSheet
{
    public class CreateDataSheetCommand : IRequestHandler<CreateDataSheetRequest, CreateDataSheetResponse>
    {
        private readonly IDataSheetRepository _dataSheetRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMediator _mediator;
        public CreateDataSheetCommand(IDataSheetRepository dataSheetRepository, IDoctorRepository doctorRepository, IMediator mediator)
        {
            _dataSheetRepository = dataSheetRepository;
            _doctorRepository = doctorRepository;
            _mediator = mediator;
        }

        public async Task<CreateDataSheetResponse> Handle(CreateDataSheetRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new CreateDataSheetResponse() { Success = false, Message = "Request empty" };

            // Adicionar uma pesquisa por um identifier de login
            var doctor = await _doctorRepository.FindAsync(x => x.UserIdentifier == request.DoctorIdentifier && x.Active);
            if (doctor == null)
                return new CreateDataSheetResponse() { Success = false, Message = "Doctor not found or inactive" };

            byte[] fileData = null;
            string base64 = string.Empty;
            if (request.PacientImage != null)
            {
                foreach (string file in request.PacientImage)
                {
                    base64 = Regex.Replace(file, "data:(.*?);base64,", "");
                    fileData = Convert.FromBase64String(base64);
                }
            }

            DataSheet dataSheet = new()
            {
                Details = request?.Details,
                DoctorId = doctor.DoctorId,
                Pacient = new Pacient
                {
                    Address = request.Pacient?.Address,
                    CellphoneNumber = request.Pacient?.CellphoneNumber,
                    Cpf = request.Pacient?.Cpf,
                    Name = request.Pacient?.Name,
                    PacientImage = base64,
                }
            };

            await _dataSheetRepository.AddAsync(dataSheet);

            return new CreateDataSheetResponse() { Success = true, Message = "Data Sheet created with succesfull" };
        }
    }
}
