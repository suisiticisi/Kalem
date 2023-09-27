using Kalem.Api.Application.Interfaces.Repositories;
using Kalem.Api.Domain.Models;
using Kalem.Api.Infrastructure.Persistence.Context;

namespace Kalem.Api.Infrastructure.Persistence.Repositories
{
    public class SalesInvoiceItemRepository : GenericRepository<SalesInvoiceItem>, ISalesInvoiceItemRepository
    {
        public SalesInvoiceItemRepository(KalemContext dbContext) : base(dbContext)
        {
        }
    }
}
