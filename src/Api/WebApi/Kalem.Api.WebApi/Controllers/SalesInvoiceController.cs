using Kalem.Api.Application.Features.Commands.SalesInvoice.Create;
using Kalem.Api.Application.Features.Commands.SalesInvoice.Delete;
using Kalem.Api.Application.Features.Commands.SalesInvoice.Update;
using Kalem.Api.Application.Features.Queries.SalesInvoice.GetSalesInvices;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kalem.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesInvoiceController : ControllerBase
    {
        private readonly IMediator mediator;
        public SalesInvoiceController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("GetSalesInvoice/{InvoiceNo}/{IsInvoiceRow}")]
        public async Task<IActionResult> GetSalesInvoice(Guid InvoiceNo, bool IsInvoiceRow)
        {
            var result = await mediator.Send(new GetSalesInvoiceQuery(InvoiceNo, IsInvoiceRow));
            return Ok(result);
        }


        [HttpPost]
        [Route("CreateSalesInvoice")]
        public async Task<IActionResult> CreateSalesInvoice([FromBody] CreateSalesInvoiceCommand command)
        {
            var result = await mediator.Send(command);

            return Ok(result);
        }


        //[HttpPut]
        //[Route("Update")]
        //public async Task<IActionResult> UpdateSalesInvoice([FromBody] UpdateSalesInvoiceCommand command)
        //{
        //    var result = await mediator.Send(command);

        //    return Ok(result);
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesInvoice(Guid id)
        {
            var result = await mediator.Send(new DeleteSalesInvoiceCommand(id));

            return Ok(result);
        }
    }
}
