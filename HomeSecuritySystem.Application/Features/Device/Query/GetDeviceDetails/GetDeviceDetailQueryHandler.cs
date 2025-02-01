using AutoMapper;
using HomeSecuritySystem.Application.Contracts.Presistance;
using HomeSecuritySystem.Application.Exceptions;
using HomeSecuritySystem.Domain;
using MediatR;

namespace HomeSecuritySystem.Application.Features.Device.Query.GetDeviceDetails
{
    public class GetDeviceDetailQueryHandler : IRequestHandler<
        GetDeviceDetailQuery, DeviceDetailDto>
    {

        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;

        public GetDeviceDetailQueryHandler(
            IDeviceRepository deviceRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
        }

        public async Task<DeviceDetailDto> Handle(GetDeviceDetailQuery request, CancellationToken cancellationToken)
        {
            // query the device by id
            var device = await _deviceRepository.GetByIdAsync(request.Id);
           
            // here we check it exist or not first before deleting
            if (device == null)
                throw new NotFoundException(nameof(Device), request.Id);

            // map the device to DeviceDetailDto
            var deviceDetailDto = _mapper.Map<DeviceDetailDto>(device);

            return deviceDetailDto ;
        }
    }
}
