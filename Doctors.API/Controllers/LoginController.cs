using Doctors.Application.Commands.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Doctors.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : BaseController
    {
        public LoginController(IMediator mediator) : base(mediator)
        { }

        [HttpPost]
        //[SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(CreateDoctorResponse))]
        //[SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(CommandResponse))]
        public async Task<IActionResult> CreaterDoctor([FromBody] LoginRequest request) =>
            CreateResponse(await _mediator.Send(request, new CancellationToken()));

    }
}
