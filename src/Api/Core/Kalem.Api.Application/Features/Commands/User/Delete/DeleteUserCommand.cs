using MediatR;

namespace Kalem.Api.Application.Features.Commands.User.Delete
{
    public class DeleteUserCommand : IRequest<Response<NoContent>>
    {
        public DeleteUserCommand(Guid id)
        {
            UserId = id;
        }

        public Guid UserId { get; set; }
    }
}
