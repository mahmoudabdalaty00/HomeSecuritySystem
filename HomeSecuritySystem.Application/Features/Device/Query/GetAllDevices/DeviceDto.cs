namespace HomeSecuritySystem.Application.Features.Device.Query.GetAllDevicesw
{
    public class DeviceDto
    {

        public int Id { get; set; }

        public string DeviceType { get; set; }  

        public string Model { get; set; }  

        public bool Status { get; set; }

        public string UserId { get; set; }

    }
}
