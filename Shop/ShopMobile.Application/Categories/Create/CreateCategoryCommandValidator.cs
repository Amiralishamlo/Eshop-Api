using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Categories.Create
{
    public class CreateCategoryCommandValidator:AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(r => r.Title)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("عنوان"));

            RuleFor(r => r.Slug)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("slug"));
        }
    } 
}
