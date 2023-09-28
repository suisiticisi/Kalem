
using Kalem.Api.Application.Interfaces.Repositories;
using MediatR;

namespace Kalem.Api.Application.Features.Commands.SalesInvoice.Update
{
    public class UpdateSalesInvoiceCommandHandler : IRequestHandler<UpdateSalesInvoiceCommand, bool>
    {
        private readonly IDBContext context;
        private readonly ISalesInvoiceRepository _salesInvoiceRepository;
        private readonly ISalesInvoiceItemRepository _salesInvoiceItemRepository;
        private readonly IProductRepository _productRepository;
        public UpdateSalesInvoiceCommandHandler(ISalesInvoiceRepository salesInvoiceRepository, ISalesInvoiceItemRepository salesInvoiceItemRepository, IProductRepository productRepository, IDBContext context)
        {
            _salesInvoiceRepository = salesInvoiceRepository;
            _salesInvoiceItemRepository = salesInvoiceItemRepository;
            _productRepository = productRepository;
            this.context = context;
        }
        public async Task<bool> Handle(UpdateSalesInvoiceCommand request, CancellationToken cancellationToken)
        {

            await using var transaction = await context.database.BeginTransactionAsync();

            try
            {
                var dbsalesInvoice = _salesInvoiceRepository.AsQueryable().FirstOrDefault(x => x.InvoiceNo == request.InvoiceNo);
                var dbSalesInvoiceItems = await _salesInvoiceItemRepository.GetAll();


                var dbSalesInvoiceItem = dbSalesInvoiceItems.Where(x => x.SalesInvoiceId == dbsalesInvoice.Id);

                var productIds = dbSalesInvoiceItem.Select(x => x.ProductId).ToList();



                var listDelete = new List<ProductAmount>();
                var listAdd = new List<ProductAmount>();

                var addProducts = request.ProductAmounts.Where(x => !productIds.Contains(x.ProductId)).ToList();
                var addProductsIds = addProducts.Select(x => x.ProductId).ToList();


                foreach (var item in request.ProductAmounts.Where(x => !addProductsIds.Contains(x.ProductId)))
                {
                    var amountIndb = _salesInvoiceItemRepository.AsQueryable().Where(x => x.ProductId == item.ProductId && x.SalesInvoiceId == dbsalesInvoice.Id).FirstOrDefault().Amount;

                    if (item.Amount != amountIndb)
                    {
                        listDelete.Add(new ProductAmount { ProductId = item.ProductId, Amount = item.Amount });
                        listAdd.Add(new ProductAmount { ProductId = item.ProductId, Amount = item.Amount });

                    }


                }

                addProducts.AddRange(listAdd);

                var deleteProducst = productIds.Where(x => !request.ProductAmounts.Select(x => x.ProductId).Contains(x)).ToList();

                deleteProducst.AddRange(listDelete.Select(x => x.ProductId));

                if (deleteProducst != null)
                {
                    foreach (var item in deleteProducst)
                    {
                        var salesItem = dbSalesInvoiceItems.Find(x => x.ProductId == item && x.SalesInvoiceId == dbsalesInvoice.Id);

                        await _salesInvoiceItemRepository.DeleteAsync(salesItem);

                    }
                }
                foreach (var item in addProducts)
                {
                    var productPreis = _productRepository.GetByIdAsync(item.ProductId).Result.UnitPrice;
                    await _salesInvoiceItemRepository.AddAsync(new Domain.Models.SalesInvoiceItem()
                    {
                        ProductId = item.ProductId,
                        Amount = item.Amount,
                        CreateDate = DateTime.UtcNow,
                        TotalAmount = item.Amount * productPreis,
                        SalesInvoiceId = dbsalesInvoice.Id,
                        ItemNo = Guid.NewGuid()

                    });
                }



                await transaction.CommitAsync();
                await context.SaveChangesAsync(cancellationToken);
            }



            catch (Exception)
            {

                throw;
            }
            return true;
        }
    }
}
