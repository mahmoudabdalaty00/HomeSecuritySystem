using FluentValidation;
using HomeSecuritySystem.Application.Contracts.Presistance;

namespace HomeSecuritySystem.Application.Features.House.Commands.CreateHouse
{
    public class CreateHouseCommandValidator :
        AbstractValidator<CreateHouseCommand>
    {
        private readonly IHomeRepository _homeRepository;

        public CreateHouseCommandValidator(IHomeRepository homeRepository)
        {
            //we choose to validate anything we need  of the house
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50)
                .WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(p => p.Address)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50)
                .WithMessage("{PropertyName} must not exceed 50 characters.");


            RuleFor(p => p.City)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50)
                .WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(h => h.Region)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull()
              .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(h => h.PostalCode)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

            RuleFor(h => h.Country)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p)
                .MustAsync(HouseExist)
                .WithMessage("House already exists");

            _homeRepository = homeRepository;
        }

        private async Task<bool> HouseExist(CreateHouseCommand command, CancellationToken token)
        {
            // check if the house already exists if it does, return false to the validator  to show the error message     
            // if it isnot work delete ==false because i added it to make the test pass
            return await _homeRepository.HouseExist(command.Id) == false;
        }
    }
}
