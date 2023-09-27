using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalem.Api.Domain.Models
{
    public  class SalesInvoice:BaseEntity
    {
        public SalesInvoice()
        {
            SalesInvoiceItems=new List<SalesInvoiceItem>();

        }
        public Guid InvoiceNo { get; set; }

       // public DateTime InvoiceTime { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public virtual ICollection<SalesInvoiceItem> SalesInvoiceItems { get; set; } 
    }
}
