﻿
using Kalem.Api.Application.Models.Queries;
using MediatR;

namespace Kalem.Api.Application.Features.Commands.User.Login
{
    public class LoginUserCommand : IRequest<LoginUserViewModel>
    {
        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public LoginUserCommand(string emailAddress, string password)
        {
            EmailAddress = emailAddress;
            Password = password;
        }

        public LoginUserCommand()
        {

        }
    }
}