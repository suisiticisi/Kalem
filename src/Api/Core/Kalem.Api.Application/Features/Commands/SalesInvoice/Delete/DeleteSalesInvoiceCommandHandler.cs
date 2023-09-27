
using Kalem.Api.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
//using static System.Formats.Asn1.AsnWriter;

namespace Kalem.Api.Application.Features.Commands.SalesInvoice.Delete
{
    public class DeleteSalesInvoiceCommandHandler : IRequestHandler<DeleteSalesInvoiceCommand, bool>
    {
        private readonly IDBContext context;
        private readonly ISalesInvoiceRepository _salesInvoiceRepository;
        private readonly ISalesInvoiceItemRepository _salesInvoiceItemRepository;

        public DeleteSalesInvoiceCommandHandler(ISalesInvoiceItemRepository salesInvoiceItemRepository, ISalesInvoiceRepository salesInvoiceRepository, IDBContext context)
        {
            _salesInvoiceItemRepository = salesInvoiceItemRepository;
            _salesInvoiceRepository = salesInvoiceRepository;
            this.context = context;
        }

        public async Task<bool> Handle(DeleteSalesInvoiceCommand request, CancellationToken cancellationToken)
        {
            var ben = context.Products.FirstOrDefault();
            var executionStrategy = context.database.CreateExecutionStrategy();

        
            await using var transaction = await context.database.BeginTransactionAsync();
            try
            {
                var query = _salesInvoiceRepository.AsQueryable()
                    .Include(_ => _.SalesInvoiceItems).ThenInclude(_ => _.Product)
                    .Include(_ => _.User).ThenInclude(_ => _.Role).ToList();

                var salesInvoice = query.Where(x => x.InvoiceNo == request.InvoiceNo).First();
                salesInvoice.Status = false;

               // _salesInvoiceRepository.Delete(salesInvoice);

                var salesInvoiceItems = query.Where(x => x.InvoiceNo == request.InvoiceNo).Select(x => x.SalesInvoiceItems).First();

                foreach (var item in salesInvoiceItems)
                {
                    item.Status = false;
                  //  _salesInvoiceItemRepository.Delete(item);
                }

                await transaction.CommitAsync(); // Commit the transaction
              await  context.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(); // Rollback the transaction in case of an exception
                throw; // Re-throw the exception after rolling back
            }


        }

    }
}
