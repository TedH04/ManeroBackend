using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Dtos;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;

        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddressRequest request)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _addressService.GetOrCreateAsync(request));
            }

            return BadRequest();
        }
    }
}
