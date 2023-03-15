using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Template.Data.Models;
using Template.Services;
using Template.Services.Interfaces;
using Template.Api.ViewModels;

namespace Template.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectsService _service;

        public ProjectsController(IProjectsService service)
        {
            _service = service;
        }

        [SwaggerOperation(Summary = "Get Project By Id")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Project))]
        [HttpGet("[action]")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            try
            {
                var project = await _service.Get(id);

                return Ok(project);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [SwaggerOperation(Summary = "List Projects")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Tuple<IEnumerable<Project>, int>))]
        [HttpGet("[action]")]
        public async Task<IActionResult> List([FromQuery] int skip, int take, string sortBy, string sortOrder)
        {
            try
            {
                var projects = await _service.List(skip, take, sortBy, sortOrder);

                return Ok(projects);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [SwaggerOperation(Summary = "Create Project")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Project))]
        [HttpPost("[action]")]
        public async Task<IActionResult> Create(ProjectVM project)
        {
            try
            {
                //mapper
                var newProject = new Project()
                {
                    ID = project.ID,
                    Name = project.Name,
                    Description = project.Description,
                    StartDate = project.StartDate,
                    ExpectedEndDate = project.ExpectedEndDate,
                    EndDate = project.EndDate,
                    TeamID = project.TeamID
                };

                await _service.Create(newProject);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [SwaggerOperation(Summary = "Update Project")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ProjectVM))]
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(ProjectVM project)
        {
            try
            {
                //mapper
                var updateProject = new Project()
                {
                    ID = project.ID,
                    Name = project.Name,
                    Description = project.Description,
                    StartDate = project.StartDate,
                    ExpectedEndDate = project.ExpectedEndDate,
                    EndDate = project.EndDate,
                    TeamID = project.TeamID
                };

                await _service.Update(updateProject);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [SwaggerOperation(Summary = "Delete Project")]
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
