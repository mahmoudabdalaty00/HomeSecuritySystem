using HomeSecuritySystem.Application.Features.Device.Query.GetAllDevicesw;

namespace HomeSecuritySystem.Application.Features.House.Query.GetHouseDetails
{
    public class HouseDetailDto
    {

        public int Id { get; set; }

        public string? Name { get; set; }


        public string? Address { get; set; }


        public string? City { get; set; }


        public string? Region { get; set; }


        public string? PostalCode { get; set; }

        public ICollection<DeviceDto>? Devices { get; set; }
        // public ICollection<UserDto> Users { get; set; }
    }
}
