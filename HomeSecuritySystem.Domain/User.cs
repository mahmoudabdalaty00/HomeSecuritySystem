using System.ComponentModel.DataAnnotations;

namespace HomeSecuritySystem.Domain
{
    public class User
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string? Username { get; set; }
        [Required]
        public string? PasswordHash { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Role { get; set; }

    }

}
