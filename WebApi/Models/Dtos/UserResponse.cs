using WebApi.Models.Identity;

namespace WebApi.Models.Dtos
{
	public class UserResponse
	{
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string? PhoneNumber { get; set; }
		public string? ProfileImage { get; set; }
	}
}
