using MediatR;

namespace HomeSecuritySystem.Application.Features.Device.Query.GetAllDevicesw
{
    public record GetDevicesQuery : IRequest<List<DeviceDto>>;
}
