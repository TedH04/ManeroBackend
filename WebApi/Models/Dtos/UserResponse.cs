namespace WebApi.Models.Dtos
{
    public class UserResponse
	{
		public string UserId { get; set; } = null!;
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string PhoneNumber { get; set; } = null!;
		public string? ProfileImage { get; set; }
	}
}
