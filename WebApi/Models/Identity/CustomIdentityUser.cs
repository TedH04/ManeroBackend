﻿using Microsoft.AspNetCore.Identity;
using WebApi.Models.Entities;

namespace WebApi.Models.Identity
{
	public class CustomIdentityUser : IdentityUser
	{
        public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
        public string? ProfileImage { get; set; }

		public ICollection<UserAddressEntity>? UserAddresses { get; set; } = new HashSet<UserAddressEntity>();
    }
}
