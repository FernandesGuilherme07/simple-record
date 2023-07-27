using Microsoft.AspNetCore.Mvc;
using simple_record.service.InputModels;
using simple_record.service.Services.Contracts;

namespace simple_record.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressPersonController : ControllerBase
    {
        private readonly IAddressPersonService _addressPersonService;

        public AddressPersonController(IAddressPersonService addressPersonService)
        {
            _addressPersonService = addressPersonService;
        }

        [HttpPost("CreateAddressPerson")]
        public async Task<IActionResult> CreateAddressPerson([FromBody] CreateAddressPersonInputModel model)
        {
            try
            {
                var result = await _addressPersonService.CreateAddressPerson(model);
                if (result.success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred");
            }
        }

        [HttpDelete("DeleteAddressPerson")]
        public async Task<IActionResult> DeleteAddressPerson(DeleteAddressPersonInputModel model)
        {
            try
            {
                var result = await _addressPersonService.DeleteAddressPerson(model);
                if (result.success)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound(result);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred");
            }
        }
    }
}
