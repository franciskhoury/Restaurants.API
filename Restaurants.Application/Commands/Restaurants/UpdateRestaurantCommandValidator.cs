using FluentValidation;

namespace Restaurants.Application.Commands.Restaurants;
public class UpdateRestaurantCommandValidator : AbstractValidator<UpdateRestaurantCommand>
{
    public UpdateRestaurantCommandValidator()
    {
        _ = RuleFor(c => c.Name).Length(3, 100);
    }
}
