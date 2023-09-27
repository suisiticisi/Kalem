using Kalem.Api.Application.Features.Commands.Product.Create;
using Kalem.Api.Application.Features.Commands.Product.Delete;
using Kalem.Api.Application.Features.Commands.Product.Update;
using Kalem.Api.Application.Features.Commands.User.Create;
using Kalem.Api.Application.Features.Queries.Product;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kalem.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] GetProductQuery query)
        {
            var res = await mediator.Send(query);

            return Ok(res);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            var res = await mediator.Send(command);

            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await mediator.Send(new DeleteProductCommand(id));
            return Ok(response);

        }

        [HttpPut]
        [Route("Update")]
   
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            var guid = await mediator.Send(command);

            return Ok(guid);
        } 

    }
}
