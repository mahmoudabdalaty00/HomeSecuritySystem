using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeSecuritySystem.Application.Features.Device.Query.GetDeviceDetails
{
    public class DeviceDetailDto
    {

        public int Id { get; set; }

        public string DeviceType { get; set; }  

        public string Model { get; set; }  

        public bool Status { get; set; }

        public string UserId { get; set; }
    }
}
