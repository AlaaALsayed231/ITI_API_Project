using Bug_Ticketing.BL;
using Bug_Ticketing.BL.DTOS.Projects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectManager _projectManager;

        public ProjectController(IProjectManager projectManager)
        {
            _projectManager = projectManager;
        }
        [HttpGet]
        public async Task<Ok<List<ProjectReadDto>>> GetAll()
        {
            return TypedResults.Ok(await _projectManager.GetAllAsynic());
        }

        [HttpPost]
        public async Task<NoContent> Add(ProjectAddDto project)
        {
            await _projectManager.AddAsync(project);
            return TypedResults.NoContent();
        }
        [HttpGet("{id}")]
        public async Task<Results<Ok<ProjectDetailsDto>, NotFound>> GetByIdWithBugs(int id)
        {
            var ProjectDto = await _projectManager.GetProjectWithBugsAsync(id);

            if (ProjectDto is null)
                return TypedResults.NotFound();

            return TypedResults.Ok(ProjectDto);
        }


    }
}
