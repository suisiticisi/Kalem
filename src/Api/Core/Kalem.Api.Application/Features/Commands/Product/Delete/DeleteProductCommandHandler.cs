using Kalem.Api.Application.Interfaces.Repositories;
using MediatR;

namespace Kalem.Api.Application.Features.Commands.Product.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand,Response<NoContent>>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Response<NoContent>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
           // var product = await _productRepository.DeleteAsync(request.ProductId);
            var product = await _productRepository.GetByIdAsync(request.ProductId);
            if (product == null)
            {
                return Response<NoContent>.Fail("Product not found", 404);
                   
            }else
            {
                product.Status = false;
               await _productRepository.UpdateAsync(product);
                return Response<NoContent>.Success(204);
            }

        }
    }
}
