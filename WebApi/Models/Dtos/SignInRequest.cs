using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Dtos
{
    public class SignInRequest
    {
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
