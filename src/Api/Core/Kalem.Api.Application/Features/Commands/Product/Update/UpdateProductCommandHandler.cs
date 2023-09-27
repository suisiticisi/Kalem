using AutoMapper;
using Kalem.Api.Application.Interfaces.Repositories;
using Kalem.Api.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalem.Api.Application.Features.Commands.Product.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Guid>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<Guid> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var dbProduct = await _productRepository.GetByIdAsync(request.Id);
            if (dbProduct is null)
                throw new DatabaseValidationException("Product not found!");

            mapper.Map(request, dbProduct);

            await _productRepository.UpdateAsync(dbProduct);
            return dbProduct.Id;
        }
    }
}
