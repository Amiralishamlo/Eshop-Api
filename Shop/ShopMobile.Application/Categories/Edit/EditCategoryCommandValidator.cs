using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Categories.Edit
{
    public class EditCategoryCommandValidator : AbstractValidator<EditCategoryCommand>
    {
        public EditCategoryCommandValidator()
        {
            RuleFor(r => r.Title)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("عنوان"));

            RuleFor(r => r.Slug)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("slug"));
        }
    }
}
