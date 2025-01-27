using FluentValidation;
using GameStore.Controllers;
using GameStore.Models.DTO;
using GameStore.Models.Requests;

namespace GameStore.Validators
{
    public class AddGameRequestValidator : AbstractValidator<AddGameRequest>
    {
        public AddGameRequestValidator()
        {
            RuleFor(x => x.Title).NotEmpty().NotNull().MaximumLength(100).MinimumLength(2);
            RuleFor(x => x.Price).GreaterThan(0).NotNull().WithMessage("Price must be greater than zero and should not be null.");
          
            RuleFor(x => x.AfterDate).NotEmpty().NotNull().WithMessage("Release date is required and should not be null.");
          
        }
    }
}
