using Doctors.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.Application.Commands.CreateDoctor
{
    public class CreateDoctorRequest : IRequest<CreateDoctorResponse>
    {
        public required string Name { get; set; }

        public required string Cpf { get; set; }

        public required string Crm { get; set; }

        public required string Specialty { get; set; }
        public bool Active { get; set; } = true;
    }
}
