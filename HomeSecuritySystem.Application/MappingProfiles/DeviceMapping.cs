using AutoMapper;
using HomeSecuritySystem.Application.Features.Device.Query.GetAllDevicesw;
using HomeSecuritySystem.Application.Features.Device.Query.GetDeviceDetails;
using HomeSecuritySystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeSecuritySystem.Application.MappingProfiles
{
    public class DeviceProfile :Profile
    {
        public DeviceProfile()
        {
            CreateMap<DeviceDto,Device>().ReverseMap();
            CreateMap <Device , DeviceDetailDto>(); 
        }
    }
}
