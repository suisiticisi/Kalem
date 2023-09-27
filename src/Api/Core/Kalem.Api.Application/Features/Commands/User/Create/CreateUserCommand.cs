using Kalem.Api.Application.Features.Queries.User;
using MediatR;

namespace Kalem.Api.Application.Features.Commands.User.Create
{
    public  class CreateUserCommand:IRequest<Response<Guid>>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Tckn { get; set; }
        public DateTime Birthday { get; set; }
        public bool Active { get; set; }
        public string Password { get; set; }

        public string EmailAddress { get; set; }
        public Guid RoleId { get; set; }

     
    }
}
