using FluentValidation;
using HomeSecuritySystem.Application.Contracts.Presistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeSecuritySystem.Application.Features.Device.Commands.CreateDevice
{
    public  class CreateDeviceCommandValidator
        : AbstractValidator<CreateDeviceCommand>
    {

        private readonly IDeviceRepository _deviceRepository;
        public CreateDeviceCommandValidator(IDeviceRepository deviceRepository)
        {
            RuleFor(p => p.DeviceType)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(p => p.Model)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
           
             
             RuleFor(p => p )
                 .MustAsync(DeviceExist)
                 .WithMessage("Device already exists");

            _deviceRepository = deviceRepository;
        }

        private async Task<bool> DeviceExist(CreateDeviceCommand command, CancellationToken token)
        {
            return await _deviceRepository.DeviceExist(command.DeviceType, command.Model, command.UserId) == false ;
        }
    }
}
