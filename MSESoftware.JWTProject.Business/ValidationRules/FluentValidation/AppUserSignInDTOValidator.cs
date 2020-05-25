using FluentValidation;
using MSESoftware.JWTProject.Entities.DTOs.AppUserDTOs;

namespace MSESoftware.JWTProject.Business.ValidationRules.FluentValidation
{
    public class AppUserSignInDTOValidator : AbstractValidator<AppUserSignInDTO>
    {
        public AppUserSignInDTOValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username cannot be empty");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty");
        }
    }
}
