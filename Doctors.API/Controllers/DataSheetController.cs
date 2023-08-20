using Doctors.Application.Commands.CreateDataSheet;
using Doctors.Application.Commands.DeleteDataSheet;
using Doctors.Application.Commands.UpdateDataSheet;
using Doctors.Application.Queries.ListDataSheet;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Doctors.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Doctor")]
    public class DataSheetController : BaseController
    {
        public DataSheetController(IMediator mediator) : base(mediator)
        { }

        [HttpPost("create")]
        //[SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(CreateDoctorResponse))]
        //[SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(CommandResponse))]
        public async Task<IActionResult> CreaterDataSheet([FromBody] CreateDataSheetRequest request)
        {
            var user = User.Claims.AsQueryable().FirstOrDefault();
            request.DoctorIdentifier = user.Value;
            return CreateResponse(await _mediator.Send(request, new CancellationToken()));
        }

        [HttpPut("delete/{id}")]
        //[SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(CreateDoctorResponse))]
        //[SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(CommandResponse))]
        public async Task<IActionResult> DeleteDataSheet([FromBody] DeleteDataSheetRequest request, [FromRoute] int id)
        {
            var user = User.Claims.AsQueryable().FirstOrDefault();
            request.DoctorIdentifier = user.Value;
            request.DataSheedId = id;
            return CreateResponse(await _mediator.Send(request, new CancellationToken()));
        }

        [HttpPut("update/{id}")]
        //[SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(CreateDoctorResponse))]
        //[SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(CommandResponse))]
        public async Task<IActionResult> UpdateDataSheet([FromBody] UpdateDataSheetRequest request, [FromRoute] int id)
        {
            var user = User.Claims.AsQueryable().FirstOrDefault();
            request.DoctorIdentifier = user.Value;
            request.DataSheetId = id;
            return CreateResponse(await _mediator.Send(request, new CancellationToken()));
        }

        [HttpGet("list")]
        public async Task<IActionResult> ListDoctorDataSheets([FromQuery] ListDataSheetRequest request)
        {
            var user = User.Claims.AsQueryable().FirstOrDefault();
            request.DoctorIdentifier = user.Value;
            return CreateResponse(await _mediator.Send(request, new CancellationToken()));
        }
    }
}
