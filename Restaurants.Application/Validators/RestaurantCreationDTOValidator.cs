using FluentValidation;

using Restaurants.Application.DTOs;

namespace Restaurants.Application.Validators;
public class RestaurantCreationDTOValidator : AbstractValidator<RestaurantCreationDTO>
{
    public RestaurantCreationDTOValidator()
    {
        _ = RuleFor(dto => dto.Name)
            .Length(3, 100);
        _ = RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("A Description is required.");
        _ = RuleFor(dto => dto.Category)
            .NotEmpty().WithMessage("A Category is required.");
        _ = RuleFor(dto => dto.ContactEmail)
            .EmailAddress().WithMessage("A valid email address is required.");
        _ = RuleFor(dto => dto.PostalCode)
            .Matches(@"^\d{5}(-\d{4})?$")
            .WithMessage("Please provide a valid US Zip Code.");
        _ = RuleFor(dto => dto.State)
            .Matches(@"^[A-Z]{2}$")
            .WithMessage("Please provide a 2-letter State code.");
        _ = RuleFor(dto => dto.ContactPhoneNumber)
            .Matches(@"^\d{3}-\d{3}-\d{4}$")
            .WithMessage("Please provide Phone Number (999-999-9999).");
    }
}
