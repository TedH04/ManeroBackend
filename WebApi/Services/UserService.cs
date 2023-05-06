using System.Security.Claims;
using WebApi.Helpers.Jwt;
using WebApi.Models.Dtos;
using WebApi.Models.Identity;
using WebApi.Repositories;

namespace WebApi.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepo;
        private readonly JwtToken _jwtToken;

        public UserService(UserRepository userRepo, JwtToken jwtToken)
        {
            _userRepo = userRepo;
            _jwtToken = jwtToken;
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
            var identityUser = await _userRepo.FindUserByEmailAsync(request.Email);

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

                    return _jwtToken.Generate(claimsIdentity, DateTime.Now.AddHours(1));
                }
            }

            return string.Empty;
        }

        public async Task<UserResponse> GetUserAsync(string userId)
        {
            var user = await _userRepo.GetAsync(x => x.Id == userId);
            if (user != null)
            {
                return (UserResponse)user;
            }

            return null!;
        }

        public async Task<UserResponse> UpdateUserAsync(UserUpdateRequest request)
        {
            var user = await _userRepo.FindUserByIdAsync(request.UserId);
            if (user != null)
            {
                user.FirstName = request.FirstName ?? user.FirstName;
                user.LastName = request.LastName ?? user.LastName;
                user.Email = request.Email ?? user.Email;
                user.PhoneNumber = request.PhoneNumber ?? user.PhoneNumber;
                user.ProfileImage = request.ProfileImage ?? user.ProfileImage;

                return await _userRepo.UpdateAsync(user);
            }

            return null!;
        }
    }
}
