using FluentValidation;
using FluentValidation.Validators;

namespace Kalem.Api.Application.Features.Commands.User.Login
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(i => i.EmailAddress)
             .NotNull()
             .EmailAddress(EmailValidationMode.AspNetCoreCompatible) 
             .WithMessage("{PropertyName} not a valid email address");

            RuleFor(i => i.Password)
                .NotNull()
                .MinimumLength(3).WithMessage("{PropertyName} should at least be {MinimumLength(3)} characters");
        }
    }
}
