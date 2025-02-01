using MediatR;

namespace HomeSecuritySystem.Application.Features.Device.Query.GetDeviceDetails
{
    public record GetDeviceDetailQuery (int Id) : IRequest<DeviceDetailDto>;
}
