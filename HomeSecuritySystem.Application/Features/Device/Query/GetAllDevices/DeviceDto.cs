namespace HomeSecuritySystem.Application.Features.Device.Query.GetAllDevicesw
{
    public class DeviceDto
    {

        public int Id { get; set; }

        public string DeviceType { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        public bool Status { get; set; }

        public int UserId { get; set; }

    }
}
