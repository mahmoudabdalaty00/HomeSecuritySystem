using System.ComponentModel.DataAnnotations;

namespace HomeSecuritySystem.Domain
{
    public class Device
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DeviceType { get; set; }  
        [Required]
        public string Model { get; set; } 

        public bool Status { get; set; }

        [Required]
        public string UserId { get; set; }

    }

}
