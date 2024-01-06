using FluentValidation;
using ShoppingAPI.Models.Dto.Category;

namespace ShoppingAPI.Validators
{
    public class CategoryValidator : AbstractValidator<AddCategoryDto>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage("Category Name is required");
        }
    }
}
