namespace Kalem.Api.Application.Features.Queries.User.GetUsers
{
    public class GetUsersViewModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Role { get; set; }
        public string EmailAddress { get; set; }

    }
}
