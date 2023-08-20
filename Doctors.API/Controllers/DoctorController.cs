using Doctors.Application.Commands.CreateDoctor;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Doctors.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : BaseController
    {
        public DoctorController(IMediator mediator) : base(mediator)
        { }

        [HttpPost("create")]
        //[SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(CreateDoctorResponse))]
        //[SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(CommandResponse))]
        public async Task<IActionResult> CreaterDoctor([FromBody] CreateDoctorRequest request) =>
            CreateResponse(await _mediator.Send(request, new CancellationToken()));

    }
}
