using System.ComponentModel.DataAnnotations;

namespace tunder.BusinessObject.Requests
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [StringLength(128, MinimumLength = 8)]
        public string Password { get; set; }
    }
}