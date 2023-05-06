using System.ComponentModel.DataAnnotations;
using WebApi.Models.Identity;

namespace WebApi.Models.Dtos
{
	public class SignUpRequest
	{
        [Required(ErrorMessage = "First name is required")]
        [MinLength(2, ErrorMessage = "First name must be atleast 2 characters")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last name is required")]
        [MinLength(2, ErrorMessage = "Last name must be atleast 2 characters")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Email is required")]
        [MinLength(6, ErrorMessage = "Email must be atleast 6 characters")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Email is in wrong format")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be atleast 8 characters")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$",
            ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character. It must be at least 8 characters long.")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Phonenumber is required")]
        [RegularExpression(@"^\+(?=[0-9]{2,3})([0-9]{2,3})[0-9]{6,14}$", ErrorMessage = "Phonenumber is in wrong format")]
        public string PhoneNumber { get; set; } = null!;
        
		public string? ProfileImage { get; set; }

        public static implicit operator CustomIdentityUser(SignUpRequest request)
        {
            return new CustomIdentityUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                UserName = request.Email
            };
        }
    }
}
