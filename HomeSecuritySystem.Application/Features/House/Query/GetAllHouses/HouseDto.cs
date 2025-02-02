using HomeSecuritySystem.Application.Features.Device.Query.GetAllDevicesw;
using HomeSecuritySystem.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeSecuritySystem.Application.Features.House.Query.GetAllHouses
{
    public class HouseDto
    {
       
        public int Id { get; set; }
  
        public string Name { get; set; }

        
        public string Address { get; set; }

        
        public string City { get; set; }

       
        public string Region { get; set; }

       
        public string PostalCode { get; set; }

      // public ICollection<DeviceDto>? Devices { get; set; }
       // public ICollection<UserDto> Users { get; set; }

    }
}
