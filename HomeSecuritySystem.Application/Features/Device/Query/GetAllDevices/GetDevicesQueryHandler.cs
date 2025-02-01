using AutoMapper;
using HomeSecuritySystem.Application.Contracts.Presistance;
using HomeSecuritySystem.Application.Exceptions;
using HomeSecuritySystem.Domain;
using MediatR;

namespace HomeSecuritySystem.Application.Features.Device.Query.GetAllDevicesw
{
    public class GetDevicesQueryHandler : IRequestHandler
        <GetDevicesQuery, List<DeviceDto>>
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;
        public GetDevicesQueryHandler(IDeviceRepository deviceRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
        }
        public async Task<List<DeviceDto>> Handle
            (GetDevicesQuery request, CancellationToken cancellationToken)
        {
            //query database 
            var devices = await _deviceRepository.GetAllAsync();

            // here we check it exist or not first before deleting
            if (devices == null)
                throw new NotFoundException(nameof(Device), request);


            //convert database obj to dto obj 
            var deviceDto = _mapper.Map<List<DeviceDto>>(devices);

            //return dto obj 
            return deviceDto;
        }
    }
}
