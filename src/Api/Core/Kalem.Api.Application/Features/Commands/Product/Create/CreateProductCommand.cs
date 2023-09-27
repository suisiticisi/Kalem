using Kalem.Api.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalem.Api.Application.Features.Commands.Product.Create
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public Guid BrandId { get; set; }

        public bool Active { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
