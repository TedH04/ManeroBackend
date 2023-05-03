using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entities;

namespace WebApi.Contexts
{
	public class IdentityContext : IdentityDbContext
	{
		public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
		{

		}

		public DbSet<AddressEntity> Addresses { get; set; }
		public DbSet<UserAddressEntity> UserAddresses { get; set; }
	}
}
