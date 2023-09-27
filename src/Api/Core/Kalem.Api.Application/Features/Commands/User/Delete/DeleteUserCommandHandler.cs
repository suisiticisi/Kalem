using Kalem.Api.Application.Interfaces.Repositories;
using MediatR;

namespace Kalem.Api.Application.Features.Commands.User.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Response<NoContent>>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async  Task<Response<NoContent>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.DeleteAsync(request.UserId);
            if (user == null)
            {
                return Response<NoContent>.Fail("User not found", 404);

            }
            else
            {
                return Response<NoContent>.Success(204);
            }
        }
    }
}
