using Microsoft.AspNetCore.Identity;
using WebApi.Contexts;
using WebApi.Models.Identity;
using WebApi.Repositories.MainRepo;

namespace WebApi.Repositories
{
	public class UserRepository : Repository<CustomIdentityUser, IdentityContext>
	{
		private readonly UserManager<CustomIdentityUser> _userManager;
		private readonly SignInManager<CustomIdentityUser> _signInManager;

		public UserRepository(IdentityContext context, UserManager<CustomIdentityUser> userManager, SignInManager<CustomIdentityUser> signInManager) : base(context)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public async Task<IdentityResult> SignUpAsync(CustomIdentityUser entity, string password)
		{
			return await _userManager.CreateAsync(entity, password);
		}

        public async Task<SignInResult> SignInAsync(string email, string password, bool rememberMe, bool lockout)
        {
            return await _signInManager.PasswordSignInAsync(email, password, rememberMe, lockout);
        }

        public async Task<CustomIdentityUser> FindUserByEmailAsync(string email)
		{
			var identityUser = await _userManager.FindByEmailAsync(email);
			return identityUser!;
		}

        public async Task<CustomIdentityUser> FindUserByIdAsync(string id)
        {
            var identityUser = await _userManager.FindByIdAsync(id);
            return identityUser!;
        }
	}
}
