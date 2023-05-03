using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpRequest request)
        {
            if (ModelState.IsValid)
            {
                if (await _userService.SignUpAsync(request))
                {
                    return Created("", );
                }
            }
        }
    }
}
