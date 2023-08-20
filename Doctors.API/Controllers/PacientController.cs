using Doctors.Application.Queries.PacientDataSheet;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Doctors.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PacientController : BaseController
    {
        public PacientController(IMediator mediator) : base(mediator)
        { }

        [HttpGet("{id}")]
        //[SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(CreateDoctorResponse))]
        //[SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(CommandResponse))]
        public async Task<IActionResult> CreaterDoctor([FromHeader] PacientDataSheetRequest request, [FromRoute] int id, [FromQuery] string cpf)
        {
            request.Cpf = cpf;
            request.DataSheetId = id;
            return CreateResponse(await _mediator.Send(request, new CancellationToken()));
        }

    }
}
