using Kalem.Api.Application.Features.Commands.SalesInvoice.Create;
using MediatR;

namespace Kalem.Api.Application.Features.Commands.SalesInvoice.Update
{
    public class UpdateSalesInvoiceCommand : IRequest<bool>
    {
       

        public Guid InvoiceNo { get; set; }
      

        public Guid UserId { get; set; }

        public List<ProductAmount> ProductAmounts { get; set; }=new List<ProductAmount>();
    }

    public class ProductAmount
    {
        public Guid ProductId { get; set; }
        public decimal Amount { get; set; }

    }
}
