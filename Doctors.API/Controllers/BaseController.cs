using Doctors.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Doctors.API.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;
        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
        protected IActionResult CreateResponse(CommandResponse result)
        {
            if (!result.Success)
                return BadRequest(result);

            if (result is null)
                return NoContent();

            return Ok(result);
        }
    }
}
