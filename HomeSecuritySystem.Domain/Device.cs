using System.ComponentModel.DataAnnotations;

namespace HomeSecuritySystem.Domain
{
    public class Device
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DeviceType { get; set; } = string.Empty;
        [Required]
        public string Model { get; set; } = string.Empty;

        public bool Status { get; set; }

        [Required]
        public string UserId { get; set; }

    }

}
