using System;
using System.Collections.Generic;
using System.Linq;
using Bug_Ticketing.DAL.Models;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Ticketing.BL.Managers.Attachments
{
    public interface IAttachmentManager
    {
        Task<List<Attachment>> GetAttachmentsForBugAsync(int bugId);
        Task<Attachment> AddAttachmentAsync(Attachment attachment);
        Task<bool> DeleteAttachmentAsync(int attachmentId);
    }
}
