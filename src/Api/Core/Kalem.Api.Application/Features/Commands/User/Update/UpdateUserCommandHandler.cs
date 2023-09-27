using AutoMapper;
using Kalem.Api.Application.Interfaces.Repositories;
using Kalem.Api.Exceptions;
using MediatR;

namespace Kalem.Api.Application.Features.Commands.User.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
    {
        private readonly IMapper mapper;
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var dbUser = await _userRepository.GetByIdAsync(request.Id);
            if (dbUser is null)
                throw new DatabaseValidationException("User not found!");

            mapper.Map(request, dbUser);

            await _userRepository.UpdateAsync(dbUser);
            return dbUser.Id;
         
        }
    }
}
