using System.Threading.Tasks;
using API.Features.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddUser([FromBody] AddUser.Request request)
        {
            if (!ModelState.IsValid) return BadRequest();
            var res = await _mediator.Send(request);
            if (res.HasErrors) return BadRequest(res);
            return Ok(res);
        }
    }
}
