using FluentValidation;

namespace Restaurants.Application.Commands;
public class UpdateRestaurantCommandValidator : AbstractValidator<UpdateRestaurantCommand>
{
    public UpdateRestaurantCommandValidator()
    {
        _ = RuleFor(c => c.Name).Length(3, 100);
    }
}
