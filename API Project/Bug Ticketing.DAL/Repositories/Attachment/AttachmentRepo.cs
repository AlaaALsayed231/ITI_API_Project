using Bug_Ticketing.DAL.Context;
using Bug_Ticketing.DAL.Models;
using Bug_Ticketing.DAL.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Ticketing.DAL
{
    public class AttachmentRepo :GenericRepo<Attachment> ,IAttachmentRepo
    {
        private readonly BugTicketingDBContext _context;

        public AttachmentRepo(BugTicketingDBContext context)
            :base(context)
        {
            _context = context;
        }


        public async Task<List<Attachment>> GetAttachmentsForBugAsync(int bugId)
        {
            var attachments = await (from a in _context.Set<Attachment>()
                                     where a.BugId == bugId
                                     select a).ToListAsync();
            return attachments;
        }

        public async Task<Attachment> AddAttachmentAsync(Attachment attachment)
        {
            await _context.Set<Attachment>().AddAsync(attachment);
            await _context.SaveChangesAsync();
            return attachment;
        }

        public async Task<bool> DeleteAttachmentAsync(int attachmentId)
        {
            var attachment = await (from a in _context.Set<Attachment>()
                                    where a.Id == attachmentId
                                    select a).FirstOrDefaultAsync();

            if (attachment == null)
                return false;

            _context.Set<Attachment>().Remove(attachment);
            await _context.SaveChangesAsync();
            return true;
        }

        //public async Task<List<Attachment>> GetAttachmentsForBugAsync(int bugId)
        //{
        //    var attachments = await (from a in _context.Set<Attachment>()
        //                             where a.BugId == bugId
        //                             select a).ToListAsync();
        //    return attachments;
        //}

        //public async Task<Attachment> AddAttachmentAsync(Attachment attachment)
        //{
        //    await _context.Set<Attachment>().AddAsync(attachment);
        //    await _context.SaveChangesAsync();
        //    return attachment;
        //}

        //public async Task<bool> DeleteAttachmentAsync(int attachmentId)
        //{
        //    var attachment = await (from a in _context.Set<Attachment>()
        //                            where a.Id == attachmentId
        //                            select a).FirstOrDefaultAsync();
        //    if (attachment == null)
        //        return false;

        //    _context.Set<Attachment>().Remove(attachment);
        //    await _context.SaveChangesAsync();
        //    return true;
        //}

        //public async Task<List<Attachment>> GetAttachmentOfBugAsync(int bugId)
        //{
        //    return await _context.Set<Attachment>()
        //                     .Where(a => a.BugId == bugId)
        //                     .ToListAsync();
        //}




    }
}
