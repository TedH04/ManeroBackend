using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Dtos
{
    public class UserUpdateRequest
    {
        [Required]
        public string UserId { get; set; } = null!;

        [MinLength(2, ErrorMessage = "First name must be atleast 2 characters")]
        public string? FirstName { get; set; }

        [MinLength(2, ErrorMessage = "Last name must be atleast 2 characters")]
        public string? LastName { get; set; }

        [MinLength(6, ErrorMessage = "Email must be atleast 6 characters")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Email is in wrong format")]
        public string? Email { get; set; }

        [RegularExpression(@"^\+(?=[0-9]{2,3})([0-9]{2,3})[0-9]{6,14}$", ErrorMessage = "Phonenumber is in wrong format")]
        public string? PhoneNumber { get; set; }

        public string? ProfileImage { get; set; }
    }
}
