using AutoMapper;
using HomeSecuritySystem.Application.Contracts.Presistance;
using HomeSecuritySystem.Application.Exceptions;
using MediatR;

namespace HomeSecuritySystem.Application.Features.Device.Commands.CreateDevice
{
    public class CreateDeviceCommandHandler :IRequestHandler<CreateDeviceCommand,int>
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;

        public CreateDeviceCommandHandler(
            IDeviceRepository deviceRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
        }



        public async Task<int> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
        {
            // validate data 
            if (await _deviceRepository.DeviceExist(request.DeviceType, request.Model))
            {
                throw new Exception("Device with the same type and model already exists");
            }

            var validator = new CreateDeviceCommandValidator(_deviceRepository);
            var validationResult = await validator.ValidateAsync(request);

            if(validationResult.Errors.Any()) 
                    throw new BadRequestException("Device with the same type or model already exists", validationResult);

            // map request to domain object
            var device = _mapper.Map<Domain.Device>(request);

            // create and save to database
            await _deviceRepository.CreateAsync(device);
            
            //return the id of the newly created device
            return device.Id ;
        }
    }
     

}
