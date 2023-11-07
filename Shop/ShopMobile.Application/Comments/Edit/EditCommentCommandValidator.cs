using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Comments.Edit
{
    public class EditCommentCommandValidator:AbstractValidator<EditCommentCommand>
    {
        public EditCommentCommandValidator()
        {
            RuleFor(x => x.Text)
                .NotNull()
                .NotEmpty().MinimumLength(5).WithMessage(ValidationMessages.minLength("نظر", 5));
        }
    }
}
