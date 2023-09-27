using AutoMapper;
using Kalem.Api.Application.Features.Queries.User;
using Kalem.Api.Application.Interfaces.Repositories;
using Kalem.Api.Exceptions;
using MediatR;

namespace Kalem.Api.Application.Features.Commands.User.Create
{

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<Guid>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper mapper;

        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            _userRepository = userRepository;
        }


        public async Task<Response<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existsUser = await _userRepository.GetSingleAsync(i => i.EmailAddress == request.EmailAddress);
            if (existsUser is not null)
                throw new DatabaseValidationException("User already exists!");
            var dbUser = mapper.Map<Kalem.Api.Domain.Models.User>(request);
            await _userRepository.AddAsync(dbUser);
            return Response<Guid>.Success(dbUser.Id, 200);
          
        }
    } 
}
