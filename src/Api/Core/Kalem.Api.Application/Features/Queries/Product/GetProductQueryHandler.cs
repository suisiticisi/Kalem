using Kalem.Api.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalem.Api.Application.Features.Queries.Product
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Response<List<GetProductQueryViewModel>>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Response<List<GetProductQueryViewModel>>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var query= _productRepository.AsQueryable().Include(x=>x.Brand);
            var getProductQueryViewModel = query.Select(x => new GetProductQueryViewModel()
            {
                Active = x.Active,
                Name= x.Name,
                UnitPrice=x.UnitPrice,
                Brand=x.Brand.Name
            }).ToList();

            return Response<List<GetProductQueryViewModel>>.Success(getProductQueryViewModel, 200);
        }
    }
}
