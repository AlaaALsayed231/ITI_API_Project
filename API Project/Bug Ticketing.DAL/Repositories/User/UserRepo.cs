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
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        private readonly BugTicketingDBContext _context;

        public UserRepo(BugTicketingDBContext context)
            :base(context)
        {
            _context = context;
        }
        public async Task<User?> GetByEmailAsynic(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(e => e.Email == email);  
        }
    }
}
