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

public class BugRepo: GenericRepo<Bug>,IBugRepo
{
    private readonly BugTicketingDBContext _context;

    public BugRepo(BugTicketingDBContext context)
        :base(context)
    {
        _context = context;
    }

    public async Task<Bug> GetBugWithUsersAsync(int bugId)
    {
        return await _context.Bugs.Include(b => b.Users).FirstOrDefaultAsync(b => b.Id == bugId);
    }
    public async Task<Bug> GetBugWithDetailsAsync(int bugId)
    {
        return await _context.Bugs
            .Include(b => b.Project)
            .Include(b => b.Attachments)
            .Include(b => b.Users)
            .FirstOrDefaultAsync(b => b.Id == bugId);
    }
    public async Task AssignUserToBugAsync(Bug bug, User user)
    {
        bug.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveUserFromBugAsync(Bug bug, User user)
    {
        bug.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

}
