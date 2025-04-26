using Bug_Ticketing.DAL.Models;
using Bug_Ticketing.DAL.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Ticketing.DAL;

public interface IProjectRepo: IGenericRepo<Project>
{
    Task<Project?> GetProjectWithBugsAsync(int id);
}
