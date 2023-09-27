using MediatR;

namespace Kalem.Api.Application.Features.Commands.Product.Delete
{
    public class DeleteProductCommand:IRequest<Response<NoContent>>
    {
        public DeleteProductCommand(Guid id)
        {
            ProductId = id;
        }

        public Guid ProductId { get; set; }
    }
}
