using Bug_Ticketing.BL.DTOS.Projects;
using Bug_Ticketing.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Ticketing.BL
{
    public interface IProjectManager
    {
        Task<List<ProjectReadDto>> GetAllAsynic();
        Task AddAsync(ProjectAddDto projectAddDto);
         
        Task<ProjectDetailsDto?> GetProjectWithBugsAsync(int id);
    }
}
