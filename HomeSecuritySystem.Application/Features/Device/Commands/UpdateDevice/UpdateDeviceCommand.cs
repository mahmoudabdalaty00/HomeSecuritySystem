using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeSecuritySystem.Application.Features.Device.Commands.UpdateDevice
{
    public class UpdateDeviceCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string DeviceType { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public bool Status { get; set; }
        public int UserId { get; set; }
    }
}
