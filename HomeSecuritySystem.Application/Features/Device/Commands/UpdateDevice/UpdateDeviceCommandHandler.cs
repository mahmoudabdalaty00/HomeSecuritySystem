using AutoMapper;
using HomeSecuritySystem.Application.Contracts.Presistance;
using MediatR;

namespace HomeSecuritySystem.Application.Features.Device.Commands.UpdateDevice
{
    public class UpdateDeviceCommandHandler : IRequestHandler<UpdateDeviceCommand, Unit>
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;

        public UpdateDeviceCommandHandler
            (IDeviceRepository deviceRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDeviceCommand request, CancellationToken cancellationToken)
        {
            //validate data 



            // convert dto data to domain data
            var device = _mapper.Map<Domain.Device>(request);
            // update the device object in database
            await _deviceRepository.UpdateAsync(device);
            //return the unit
            return Unit.Value;
        }
    }
}
