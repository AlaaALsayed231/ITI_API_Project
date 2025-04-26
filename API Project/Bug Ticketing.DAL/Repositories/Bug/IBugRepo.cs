using Bug_Ticketing.DAL.Models;
using Bug_Ticketing.DAL.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Ticketing.DAL;

public interface IBugRepo :IGenericRepo<Bug>
{
    Task<Bug> GetBugWithDetailsAsync(int bugId);
    Task<Bug> GetBugWithUsersAsync(int bugId);
    Task AssignUserToBugAsync(Bug bug, User user);
    Task RemoveUserFromBugAsync(Bug bug, User user);
}
