using EmployeeAPI.Entities;
using EmployeeAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("GetProjectDetails")]
        public async Task<ActionResult<List<Department>>> GetProjectDetails()
        {
            var result = await _projectService.GetProjectDetails();
            return Ok(result);
        }

        [HttpPost("PushProject")]
        public ActionResult PushProject([FromBody] Project project)
        {
            if (project.ProjectName == null || string.IsNullOrEmpty(project.ProjectName))
            {
                return BadRequest("Invalid Project data.");
            }

            _projectService.PushProject(project);
            return Ok("Project added successfully.");
        }

        [HttpDelete("DeleteProject/{id}")]
        public ActionResult DeleteProject(int id)
        {
            _projectService.DeleteProject(id);
            return Ok("Project deleted successfully.");
        }


        [HttpPut("UpdateProject")]
        public ActionResult UpdateProject(Project project)
        {
            _projectService.UpdateProject(project);
            return Ok("Project Update successfully.");
        }

        [HttpGet("SearchProject")]
        public async Task<ActionResult<List<object>>> SearchProject(string? search)
        {
            var result = await _projectService.SearchProject(search);

            return Ok(result);
        }
    }
}
