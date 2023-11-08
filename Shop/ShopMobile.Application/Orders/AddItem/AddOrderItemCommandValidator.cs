using FluentValidation;

namespace Shop.Application.Orders.AddItem
{
    public class AddOrderItemCommandValidator : AbstractValidator<AddOrderItemCommand>
    {
        public AddOrderItemCommandValidator()
        {
            RuleFor(x => x.Count)
                .GreaterThanOrEqualTo(1).WithMessage("باید بیشتر از 0 باشد");
        }
    }
}
