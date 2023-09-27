using MediatR;

namespace Kalem.Api.Application.Features.Commands.SalesInvoice.Create
{
    public class CreateSalesInvoiceCommand:IRequest<Guid>
    {
     

        public DateTime InvoiceTime { get; set; }=DateTime.Now;

        public Guid UserId { get; set; }
      
        public List<ProductAmount> ProductAmounts { get; set; }
      


    }

    public class ProductAmount
    {
        public Guid ProductId { get; set; }
        public decimal Amount { get; set; }

    }
}
