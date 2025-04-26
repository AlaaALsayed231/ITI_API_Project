using Bug_Ticketing.DAL;

using System;
using System.Collections.Generic;
using System.Linq;
using Bug_Ticketing.DAL.Models;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Ticketing.BL.Managers.Attachments
{
    public class AttachmentManager : IAttachmentManager
    {
        private readonly IAttachmentRepo _attachmentRepo;

        public AttachmentManager(IAttachmentRepo attachmentRepo)
        {
            _attachmentRepo = attachmentRepo;
        }

        public async Task<List<Attachment>> GetAttachmentsForBugAsync(int bugId)
        {
            return await _attachmentRepo.GetAttachmentsForBugAsync(bugId);
        }

        public async Task<Attachment> AddAttachmentAsync(Attachment attachment)
        {
            return await _attachmentRepo.AddAttachmentAsync(attachment);
        }

        public async Task<bool> DeleteAttachmentAsync(int attachmentId)
        {
            return await _attachmentRepo.DeleteAttachmentAsync(attachmentId);
        }
    }
}

