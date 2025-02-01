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


            RuleFor(p => p )
                .MustAsync(HouseExist)
                .WithMessage("House already exists");

            _homeRepository = homeRepository;
        }

        private async Task<bool> HouseExist(CreateHouseCommand command, CancellationToken token)
        {
            return await _homeRepository.HouseExist(command.Name);
        }
    }
}
