
using Kalem.Api.Domain.Models;
using Kalem.Api.Application;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Kalem.Api.Infrastructure.Persistence.Context
{
    public  class KalemContext:DbContext, IDBContext
    {
        public KalemContext(DbContextOptions options) : base(options)
        {
                
        }
        public DbSet<User> Users { get; set; } 
        public DbSet<Product> Products { get; set; }
        
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SalesInvoice> SalesInvoices { get; set; }

        public DbSet<SalesInvoiceItem> SalesInvoiceItems { get; set; }

        public DatabaseFacade database => Database;

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {

            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
