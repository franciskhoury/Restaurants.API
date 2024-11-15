using FluentValidation;

using Restaurants.Application.DTOs;

namespace Restaurants.Application.Validators;
public class RestaurantCreationDTOValidator : AbstractValidator<RestaurantCreationDTO>
{
    private readonly List<string> _validCategories =
        ["Thai", "Indian", "Vietnamese", "Mediterranean", "Mexican", "Peruvian", "Chinese", "Japanese", "Korean", "Italian", "French", "German", "American",
        "Philippino","Malaysian","Nepalese","Spanish","Brazilian","Polish","Lebanese","Russian","Cajun","Cuban","Venezuelan"];

    /// <summary>
    /// Constructor sets up validation rules for building the RestaurantCreationDTO object.
    /// </summary>
    public RestaurantCreationDTOValidator()
    {
        _ = RuleFor(dto => dto.Name)
            .Length(3, 100);
        _ = RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("A Description is required.");
        _ = RuleFor(dto => dto.Category)
            .Must(_validCategories.Contains)
            .WithMessage("Must be a valid category.");
        //.Custom((value, context) =>
        //{
        //    var isValidCategory = _validCategories.Contains(value);
        //    if (!isValidCategory)
        //    {
        //        context.AddFailure("Category", "Must be a valid category.");
        //    }
        //});
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
            .WithMessage("The required format for Contact Phone Number is: 999-999-9999.");
    }
}
