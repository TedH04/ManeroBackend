using System.Security.Claims;
using WebApi.Models.Dtos;
using WebApi.Models.Identity;

namespace WebApi.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepo;

        public UserService(UserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<bool> SignUpAsync(SignUpRequest request)
        {
            CustomIdentityUser user = request;

            var createResult = await _userRepo.SignUpAsync(user, request.Password);

            if (createResult.Succeeded)
            {
                var signInResult = await _userRepo.SignInAsync(user.Email, request.Password, false, false);

                if (signInResult.Succeeded)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<string> SignInAsync(SignInRequest request)
        {
            var identityUser = await _userRepo.FindUserAsync(request.Email);

            if (identityUser != null)
            {
                var signInResult = await _userRepo.SignInAsync(request.Email, request.Password, false, false);

                if (signInResult.Succeeded)
                {
                    var claimsIdentity = new ClaimsIdentity
                }
            }
        }
    }
}
