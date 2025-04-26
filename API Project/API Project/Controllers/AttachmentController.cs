using Bug_Ticketing.BL.Managers.Attachments;
using Bug_Ticketing.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentsController : ControllerBase
    {
        private readonly IAttachmentManager _attachmentManager;

        public AttachmentsController(IAttachmentManager attachmentManager)
        {
            _attachmentManager = attachmentManager;
        }

        [HttpGet("{bugId}/attachments")]
        public async Task<ActionResult<List<Attachment>>> GetAttachmentsForBug(int bugId)
        {
            var attachments = await _attachmentManager.GetAttachmentsForBugAsync(bugId);
            return Ok(attachments);
        }

        [HttpPost("{bugId}/attachments")]
        public async Task<ActionResult<Attachment>> UploadAttachment(int bugId, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var filePath = Path.Combine(uploadsFolder, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var attachment = new Attachment
            {
                Path = filePath,
                BugId = bugId
            };

            var savedAttachment = await _attachmentManager.AddAttachmentAsync(attachment);

            return Ok(savedAttachment);
        }

        [HttpDelete("{bugId}/attachments/{attachmentId}")]
        public async Task<IActionResult> DeleteAttachment(int bugId, int attachmentId)
        {
            var result = await _attachmentManager.DeleteAttachmentAsync(attachmentId);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
