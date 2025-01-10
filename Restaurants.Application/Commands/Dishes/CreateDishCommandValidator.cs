using FluentValidation;

namespace Restaurants.Application.Commands.Dishes;
public class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
{
    public CreateDishCommandValidator()
    {
        _ = RuleFor(dish => dish.Name).NotEmpty()
             .WithMessage("The dish must have a name.");

        _ = RuleFor(dish => dish.Price)
             .GreaterThanOrEqualTo(0)
             .WithMessage("Price of the dish must be a non-negative number.");

        _ = RuleFor(dish => dish.Calories)
             .GreaterThanOrEqualTo(0)
             .WithMessage("Calories of the dish must be a non-negative number.");
    }
}
