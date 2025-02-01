using MediatR;
using Microsoft.Extensions.Options;

namespace HomeSecuritySystem.Application.Features.Device.Commands.DeleteDevice
{
    public class DeleteDeviceCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }

}
