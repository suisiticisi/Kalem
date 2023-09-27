using AutoMapper;
using Kalem.Api.Application.Features.Queries.Product;
using Kalem.Api.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalem.Api.Application.Features.Queries.User.GetUsers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, Response<List<GetUsersViewModel>>>
    {
        private readonly IUserRepository _userRepository;
     
        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        
        }

        public async  Task<Response<List<GetUsersViewModel>>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var query = _userRepository.AsQueryable().Include(x => x.Role);
            var getUsersViewModel = query.Select(x => new GetUsersViewModel()
            {  Id=x.Id,
               FirstName=x.FirstName,
               LastName=x.LastName,
               Role=x.Role.Name,
               EmailAddress=x.EmailAddress,
            }).ToList();

            return Response<List<GetUsersViewModel>>.Success(getUsersViewModel, 200); 
        }
    }
}
