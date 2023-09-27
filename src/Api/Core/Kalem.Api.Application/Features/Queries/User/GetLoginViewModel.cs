namespace Kalem.Api.Application.Features.Queries.User
{
    public class GetLoginViewModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Role { get; set; }
        public string Token { get; set; }

        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
