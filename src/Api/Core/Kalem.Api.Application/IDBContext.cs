
using Kalem.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Kalem.Api.Application
{
    public interface IDBContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SalesInvoice> SalesInvoices { get; set; }

        public DbSet<SalesInvoiceItem> SalesInvoiceItems { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DatabaseFacade database { get; }
    }
}
 