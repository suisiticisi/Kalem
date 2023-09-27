using Kalem.Api.Application.Features.Commands.Product.Delete;
using Kalem.Api.Application.Features.Commands.Product.Update;
using Kalem.Api.Application.Features.Commands.User.Create;
using Kalem.Api.Application.Features.Commands.User.Delete;
using Kalem.Api.Application.Features.Commands.User.Login;
using Kalem.Api.Application.Features.Commands.User.Update;
using Kalem.Api.Application.Features.Queries.Product;
using Kalem.Api.Application.Features.Queries.User.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kalem.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        //[Route("Get")]
        public async Task<IActionResult> Get([FromQuery]GetUserQuery query)
        {
            var res = await mediator.Send(query);

            return Ok(res);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var res = await mediator.Send(command);

            return Ok(res);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var res = await mediator.Send(command);

            return Ok(res);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await mediator.Send(new DeleteUserCommand(id)); 
            return Ok(response);

        }

        [HttpPut]
        [Route("Update")]

        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        {
            var guid = await mediator.Send(command);

            return Ok(guid);
        }
    }
}
