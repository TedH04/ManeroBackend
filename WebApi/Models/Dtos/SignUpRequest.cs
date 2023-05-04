using System.ComponentModel.DataAnnotations;
using WebApi.Models.Identity;

namespace WebApi.Models.Dtos
{
	public class SignUpRequest
	{
        [Required]
        [MinLength(2, ErrorMessage = "First name must be atleast 2 characters")]
        public string FirstName { get; set; } = null!;

        [Required]
        [MinLength(2, ErrorMessage = "Last name must be atleast 2 characters")]
        public string LastName { get; set; } = null!;

        [Required]
        [DataType(DataType.EmailAddress)]
        [MinLength(6, ErrorMessage = "Email must be atleast 6 characters")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Email is in wrong format")]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be atleast 8 characters")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$")]
        // TODO: Add errormessage for regex
        public string Password { get; set; } = null!;

        [Required]
        public string? PhoneNumber { get; set; }
        public string? ProfileImage { get; set; }

        public static implicit operator CustomIdentityUser(SignUpRequest request)
        {
            return new CustomIdentityUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.Email
            };
        }

    }
}
