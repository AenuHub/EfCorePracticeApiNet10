using System.ComponentModel.DataAnnotations;

namespace EfCorePracticeApiNet10.DTOs
{
    public class RegisterDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;
    }
}
