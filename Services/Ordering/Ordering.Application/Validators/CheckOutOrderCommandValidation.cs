using FluentValidation;
using Ordering.Application.Commands;

namespace Ordering.Application.Validators;

public class CheckOutOrderCommandValidation : AbstractValidator<CheckoutOrderCommand>
{
    public CheckOutOrderCommandValidation()
    {
        RuleFor(o => o.UserName)
            .NotEmpty()
            .WithMessage("{UserName} is required.")
            .NotNull()
            .MaximumLength(78)
            .WithMessage("{UserName} must not exceed 78 characters.");
        RuleFor(o => o.TotalPrice)
            .NotEmpty()
            .WithMessage("{TotalPrice} is required.")
            .GreaterThan(-1)
            .WithMessage("{TotalPrice} must be greater than zero.");
        RuleFor(o => o.EmailAddress)
            .NotEmpty()
            .WithMessage("{EmailAddress} is required.");
        RuleFor(o => o.FirstName)
            .NotEmpty()
            .NotNull()
            .WithMessage("{FirstName} is required.");
        RuleFor(o => o.LastName)
            .NotEmpty()
            .NotNull()
            .WithMessage("{LastName} is required.");
    }
}