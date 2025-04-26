
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Ticketing.DAL
{
    public interface IUnitOfWork
    {
        public IProjectRepo ProjectRepo { get; }
        public IBugRepo BugRepo { get; }
        public IUserRepo UserRepo { get; }

        public IAttachmentRepo AttachmentRepo { get; }
        Task<int> SaveChangesAsync();
    }
}
