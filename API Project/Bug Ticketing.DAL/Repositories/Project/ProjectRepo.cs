using Bug_Ticketing.DAL.Context;
using Bug_Ticketing.DAL.Models;
using Bug_Ticketing.DAL.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Ticketing.DAL;

public class ProjectRepo : GenericRepo<Project> ,IProjectRepo
{
    private readonly BugTicketingDBContext _context;

    public ProjectRepo(BugTicketingDBContext context)
        :base(context)
    {
        _context = context;
    }

    public async Task<Project?> GetProjectWithBugsAsync(int id)
    {

        return await _context.Set<Project>()
            .AsNoTracking()
            .Include(b=>b.Bugs)
            .FirstOrDefaultAsync(p => p.Id == id);
       
       

    }
}
