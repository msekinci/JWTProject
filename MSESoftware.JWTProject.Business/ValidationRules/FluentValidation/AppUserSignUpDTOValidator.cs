using FluentValidation;
using MSESoftware.JWTProject.Entities.DTOs.AppUserDTOs;

namespace MSESoftware.JWTProject.Business.ValidationRules.FluentValidation
{
    public class AppUserSignUpDTOValidator : AbstractValidator<AppUserSignUpDTO>
    {
        public AppUserSignUpDTOValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username cannot be empty");
            RuleFor(x => x.UserName).MaximumLength(50).WithMessage("Username must be max 50 character");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty");
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Full Name cannot be empty");
        }
    }
}
