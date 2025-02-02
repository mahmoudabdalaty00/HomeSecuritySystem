using FluentValidation;

namespace HomeSecuritySystem.Application.Features.House.Commands.UpdateHouse
{
    public class UpdateHouseCommandValidator : AbstractValidator<UpdateHouseCommand>
    {
        public UpdateHouseCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("House Id is required.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required.");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is required.");
            RuleFor(x => x.Region).NotEmpty().WithMessage("Region is required.");
            RuleFor(x => x.PostalCode).GreaterThan(0).WithMessage("Postal Code must be greater than 0.");
            RuleFor(x => x.Country).NotEmpty().WithMessage("Country is required.");
        }
    }
}



