using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Template.Api.ViewModels;
using Template.Data.Models;
using Template.Services;
using Template.Services.Interfaces;

namespace Template.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamsService _service;

        public TeamsController(ITeamsService service)
        {
            _service = service;
        }

        [SwaggerOperation(Summary = "Get Team By Id")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Team))]
        [HttpGet("[action]")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            try
            {
                var team = await _service.Get(id);

                return Ok(team);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [SwaggerOperation(Summary = "List Teams")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Tuple<IEnumerable<Team>, int>))]
        [HttpGet("[action]")]
        public async Task<IActionResult> List([FromQuery] int skip, int take, string sortBy, string sortOrder)
        {
            try
            {
                var teams = await _service.List(skip, take, sortBy, sortOrder);

                return Ok(teams);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [SwaggerOperation(Summary = "List All Teams")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Tuple<IEnumerable<Developer>, int>))]
        [HttpGet("[action]/All")]
        public async Task<IActionResult> List()
        {
            try
            {
                var teams = await _service.List();

                return Ok(teams);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [SwaggerOperation(Summary = "Create Team")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Team))]
        [HttpPost("[action]")]
        public async Task<IActionResult> Create(TeamVM team)
        {
            try
            {
                //mapper
                var newTeam = new Team()
                {
                    ID = team.ID,
                    Name = team.Name,
                    Description = team.Description,
                };

                await _service.Create(newTeam);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [SwaggerOperation(Summary = "Update Team")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Team))]
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(TeamVM team)
        {
            try
            {
                //mapper
                var updateTeam = new Team()
                {
                    ID = team.ID,
                    Name = team.Name,
                    Description = team.Description,
                };

                await _service.Update(updateTeam);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [SwaggerOperation(Summary = "Delete Team")]
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
