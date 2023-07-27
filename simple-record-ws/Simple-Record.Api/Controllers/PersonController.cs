using Microsoft.AspNetCore.Mvc;
using simple_record.service.InputModels;
using simple_record.service.Services.Contracts;

namespace simple_record.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonServices _personServices;

        public PersonController(IPersonServices personServices)
        {
            _personServices = personServices;
        }

        [HttpPost("CreatePerson")]
        public async Task<IActionResult> CreatePerson([FromBody] CreatePersonInputModel model)
        {
            try
            {
                var result = await _personServices.CreatePerson(model);
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

        [HttpGet("GetPersonById")]
        public async Task<IActionResult> GetPersonById([FromQuery] GetPersonByIdInputModel model)
        {
            try
            {
                var result = await _personServices.GetPersonById(model);
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

        [HttpGet("GetAllPeoples")]
        public async Task<IActionResult> GetAllPeoples([FromQuery] GetAllPeoplesInputModel model)
        {
            try
            {
                var result = await _personServices.GetAllPeoples(model);
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

        [HttpPut("UpdatePerson")]
        public async Task<IActionResult> UpdatePerson([FromBody] UpdatePersonInputModel model)
        {
            try
            {
                var result = await _personServices.UpdatePerson(model);
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

        [HttpDelete("DeletePerson")]
        public async Task<IActionResult> DeletePerson([FromQuery] DeletePersonInputModel model)
        {
            try
            {
                var result = await _personServices.DeletePerson(model);
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