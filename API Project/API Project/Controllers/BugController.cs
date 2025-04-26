using Bug_Ticketing.BL;
using Bug_Ticketing.BL.DTOS.Attachments;
using Bug_Ticketing.BL.DTOS.Bugs;
using Bug_Ticketing.BL.DTOS.Projects;
using Bug_Ticketing.BL.Managers.Projects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugController : ControllerBase
    {
        private readonly IBugManger _bugManger;

        public BugController(IBugManger bugManger)
        {
            _bugManger = bugManger;
        }

        [HttpGet]
        public async Task<Ok<List<BugReadDto>>> GetAll()
        {
            return TypedResults.Ok(await _bugManger.GetAllAsynic());
        }

        [HttpPost]
        public async Task<NoContent> Add(BugAddDto bug)
        {
            await _bugManger.AddAsynic(bug);
            return TypedResults.NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBugDetails(int id)
        {
            var bugDetails = await _bugManger.GetBugDetailsAsync(id);

            if (bugDetails == null)
                return NotFound();

            return Ok(bugDetails);
        }

        [HttpPost("{bugId}/assignees")]
        public async Task<IActionResult> AssignUserToBug(int bugId, [FromBody] int userId)
        {
            var result = await _bugManger.AssignUserAsync(bugId, userId);
            if (!result)
                return BadRequest("Cannot assign user to bug.");

            return Ok("User assigned successfully.");
        }

        [HttpDelete("{bugId}/assignees/{userId}")]
        public async Task<IActionResult> RemoveUserFromBug(int bugId, int userId)
        {
            var result = await _bugManger.UnassignUserAsync(bugId, userId);
            if (!result)
                return BadRequest("Cannot remove user from bug.");

            return Ok("User removed successfully.");
        }
    }
}
