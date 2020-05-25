using FluentValidation;
using MSESoftware.JWTProject.Entities.DTOs.ProductDTOs;

namespace MSESoftware.JWTProject.Business.ValidationRules.FluentValidation
{
    public class ProductUpdateDTOValidator : AbstractValidator<ProductUpdateDTO>
    {
        public ProductUpdateDTOValidator()
        {
            RuleFor(x => x.Id).InclusiveBetween(0, int.MaxValue);
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
        }
    }
}
