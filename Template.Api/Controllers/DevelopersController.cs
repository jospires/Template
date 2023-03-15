using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Template.Api.ViewModels;
using Template.Data.Models;
using Template.Services.Interfaces;

namespace Template.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private readonly IDevelopersService _service;

        public DevelopersController(IDevelopersService service)
        {
            _service = service;
        }

        [SwaggerOperation(Summary = "Get Developer By Id")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Developer))]
        [HttpGet("[action]")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            try
            {
                var developer = await _service.Get(id);

                return Ok(developer);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [SwaggerOperation(Summary = "List Developers Paginated")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Tuple<IEnumerable<Developer>, int>))]
        [HttpGet("[action]")]
        public async Task<IActionResult> List([FromQuery] int skip, int take, string sortBy, string sortOrder)
        {
            try
            {
                var developers = await _service.List(skip, take, sortBy, sortOrder);

                return Ok(developers);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [SwaggerOperation(Summary = "Create Developer")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Developer))]
        [HttpPost("[action]")]
        public async Task<IActionResult> Create(DeveloperVM developer)
        {
            try
            {
                //mapper
                var newDeveloper = new Developer()
                {
                    ID = developer.ID,
                    TeamID = developer.TeamID,
                    FirstName = developer.FirstName,
                    LastName = developer.LastName,
                    Email = developer.Email,
                    DateOfBirth = developer.DateOfBirth
                };

                await _service.Create(newDeveloper);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [SwaggerOperation(Summary = "Update Developer")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Developer))]
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(DeveloperVM developer)
        {
            try
            {
                //mapper
                var updateDeveloper = new Developer()
                {
                    ID = developer.ID,
                    TeamID = developer.TeamID,
                    FirstName = developer.FirstName,
                    LastName = developer.LastName,
                    Email = developer.Email,
                    DateOfBirth = developer.DateOfBirth
                };

                await _service.Update(updateDeveloper);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [SwaggerOperation(Summary = "Delete Developer")]
        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            try
            {
                await _service.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
