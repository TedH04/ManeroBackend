using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Dtos;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [Route("SignUp")]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpRequest request)
        {
            if (ModelState.IsValid)
            {
                if (await _userService.SignUpAsync(request))
                {
                    return Created("", null);
                }
            }

            return BadRequest();
        }
        
        [Route("SignIn")]
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInRequest request)
        {
            if (ModelState.IsValid)
            {
                var token = await _userService.SignInAsync(request);
                if (!string.IsNullOrEmpty(token))
                {
                    return Ok(token);
                }
            }

            return Unauthorized("Incorrect email or password");
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(string userId)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.GetUserAsync(userId);
                if (user != null)
                {
                    return Ok(user);
                }
            }

            return NotFound($"User with id '{userId}' not found");
        }

        [HttpPatch]
        public async Task<IActionResult> Update(UserUpdateRequest request)
        {
            if (ModelState.IsValid)
            {
                var updatedUser = await _userService.UpdateUserAsync(request);
                if (updatedUser != null)
                {
                    return Ok(updatedUser);
                }

                return NotFound($"User with id '{request.UserId}' not found");
            }

            return BadRequest();
        }
    }
}
