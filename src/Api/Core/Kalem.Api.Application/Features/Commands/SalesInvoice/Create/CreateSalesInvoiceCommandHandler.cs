using Kalem.Api.Application.Interfaces.Repositories;
using MediatR;

namespace Kalem.Api.Application.Features.Commands.SalesInvoice.Create
{
    public class CreateSalesInvoiceCommandHandler : IRequestHandler<CreateSalesInvoiceCommand, Guid>
    {
        private readonly ISalesInvoiceRepository _salesInvoiceRepository;
        private readonly ISalesInvoiceItemRepository _salesInvoiceItemRepository;
        private readonly IProductRepository _productRepository;
        public CreateSalesInvoiceCommandHandler(ISalesInvoiceRepository salesInvoiceRepository, ISalesInvoiceItemRepository salesInvoiceItemRepository, IProductRepository productRepository)
        {
            _salesInvoiceRepository = salesInvoiceRepository;
            _salesInvoiceItemRepository = salesInvoiceItemRepository;
            _productRepository = productRepository;
        }

        public async Task<Guid> Handle(CreateSalesInvoiceCommand request, CancellationToken cancellationToken)
        {

            var salesInvoice = new Domain.Models.SalesInvoice()
            {
                CreateDate = DateTime.Now,
                UserId = request.UserId,
                InvoiceNo = Guid.NewGuid()
            };

            await _salesInvoiceRepository.AddAsync(salesInvoice);


            foreach (var item in request.ProductAmounts)
            {
                await _salesInvoiceItemRepository.AddAsync(new Domain.Models.SalesInvoiceItem() {
                   SalesInvoiceId=salesInvoice.Id,
                   ItemNo= Guid.NewGuid(),
                   CreateDate = DateTime.Now,
                   ProductId = item.ProductId,
                   Amount = item.Amount,
                   TotalAmount=_productRepository.GetSingleAsync(x=>x.Id==item.ProductId).Result.UnitPrice*item.Amount

                });
            }
            return salesInvoice.Id;
        }
    }
}
