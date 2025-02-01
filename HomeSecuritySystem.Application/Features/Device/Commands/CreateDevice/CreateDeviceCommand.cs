using MediatR;

namespace HomeSecuritySystem.Application.Features.Device.Commands.CreateDevice
{
    public class CreateDeviceCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string DeviceType { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public bool Status { get; set; }
        public int UserId { get; set; }

    }


}
