using Bug_Ticketing.DAL.Context;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Ticketing.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        
        private readonly BugTicketingDBContext _context;

        public IProjectRepo ProjectRepo { get; }

        public IBugRepo BugRepo { get; }

        public IUserRepo UserRepo { get; }
        public IAttachmentRepo AttachmentRepo { get; }

        public UnitOfWork(IProjectRepo projectRepo ,IBugRepo bugRepo, IUserRepo userRepo,IAttachmentRepo attachmentRepo,BugTicketingDBContext context)
        {
            _context = context;
            ProjectRepo = projectRepo;
            BugRepo = bugRepo;
            UserRepo = userRepo;
            AttachmentRepo = attachmentRepo;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
