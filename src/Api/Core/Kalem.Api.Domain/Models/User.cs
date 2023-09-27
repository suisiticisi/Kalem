using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalem.Api.Domain.Models
{
    public class User:BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Tckn { get; set; }
        public DateTime Birthday { get; set; }
        public bool Active { get; set; } 
        public string Password { get; set; }

        public string EmailAddress { get; set; }
        public Guid RoleId { get; set; }

        public Role Role { get; set; }

        public virtual ICollection<SalesInvoice> SalesInvoices { get; set; }
    }
}
