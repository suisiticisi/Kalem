using MediatR;

namespace Kalem.Api.Application.Features.Queries.User.GetUsers
{
    public class GetUserQuery:IRequest<Response<List<GetUsersViewModel>>>
    {

    }
}
