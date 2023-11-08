using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Comments.Create
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(x => x.Text)
                .NotNull()
                .NotEmpty().MinimumLength(5).WithMessage(ValidationMessages.minLength("نظر", 5));
        }
    }
}
