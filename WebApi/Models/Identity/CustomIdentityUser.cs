using Microsoft.AspNetCore.Identity;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;

namespace WebApi.Models.Identity
{
	public class CustomIdentityUser : IdentityUser
	{
        public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
        public string? ProfileImage { get; set; }

		public ICollection<UserAddressEntity>? UserAddresses { get; set; } = new HashSet<UserAddressEntity>();

		public static implicit operator UserResponse(CustomIdentityUser user)
		{
			return new UserResponse
			{
				UserId = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email!,
				PhoneNumber = user.PhoneNumber!,
				ProfileImage = user.ProfileImage ??= null
			};
		}
	}
}
