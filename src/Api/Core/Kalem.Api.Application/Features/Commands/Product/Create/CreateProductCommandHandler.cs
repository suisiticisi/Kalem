using AutoMapper;
using Kalem.Api.Application.Interfaces.Repositories;
using Kalem.Api.Exceptions;
using MediatR;

namespace Kalem.Api.Application.Features.Commands.Product.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IBrandRepository brandRepository, IProductRepository productRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var existsProduct = await _productRepository.GetSingleAsync(i => i.Name == request.Name);
            if (existsProduct is not null)
                throw new DatabaseValidationException("Product already exists!");

            var dbProduct = _mapper.Map<Domain.Models.Product>(request);
            await _productRepository.AddAsync(dbProduct);
            return dbProduct.Id;
        }
    }
}
