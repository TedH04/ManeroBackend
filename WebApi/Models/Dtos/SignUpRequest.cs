using WebApi.Models.Identity;

namespace WebApi.Models.Dtos
{
	public class SignUpRequest
	{
        public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
		public string Password { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? ProfileImage { get; set; }

        public static implicit operator CustomIdentityUser(SignUpRequest request)
        {
            return new CustomIdentityUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
            };
        }

    }
}
