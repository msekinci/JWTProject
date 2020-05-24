using FluentValidation;
using MSESoftware.JWTProject.Entities.DTOs.ProductDTOs;

namespace MSESoftware.JWTProject.Business.ValidationRules.FluentValidation
{
    public class ProductAddDTOValidator : AbstractValidator<ProductAddDTO>
    {
        public ProductAddDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
        }
    }
}
