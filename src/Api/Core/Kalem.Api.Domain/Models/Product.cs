using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalem.Api.Domain.Models
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; } 
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }    
        public bool Active { get; set; }
        public DateTime ExpirationDate { get; set; }

        public virtual ICollection<SalesInvoiceItem> SalesInvoiceItems { get; set; }
    }
}
