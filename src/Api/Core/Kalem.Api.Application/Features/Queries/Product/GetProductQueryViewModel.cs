using Kalem.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalem.Api.Application.Features.Queries.Product
{
    public class GetProductQueryViewModel
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public string Brand { get; set; }
        public bool Active { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
}
