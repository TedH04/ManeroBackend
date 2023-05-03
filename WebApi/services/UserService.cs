using System.Security.Claims;
using WebApi.Models.Dtos;
using WebApi.Models.Identity;
using WebApi.Repositories;

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
            CustomIdentityUser identityUser = request;

            var createResult = await _userRepo.SignUpAsync(identityUser, request.Password);

            if (createResult.Succeeded)
            {
                var signInResult = await _userRepo.SignInAsync(identityUser.Email!, request.Password, false, false);

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
                var signInResult = await _userRepo.SignInAsync(identityUser.Email!, request.Password, false, false);

                if (signInResult.Succeeded)
                {
                    var claimsIdentity = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("id", identityUser.Id.ToString()),
                        new Claim(ClaimTypes.Name, identityUser.Email!)
                    });


                }
            }

            return string.Empty;
        }
    }
}
