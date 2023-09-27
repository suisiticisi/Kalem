using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalem.Api.Application.Features.Commands.User.Update
{
    public class UpdateUserCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Guid RoleId { get; set; }


        public string EmailAddress { get; set; }
    }
}
