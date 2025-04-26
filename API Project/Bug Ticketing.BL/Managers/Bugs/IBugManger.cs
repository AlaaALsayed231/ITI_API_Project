using Bug_Ticketing.BL.DTOS.Bugs;
using Bug_Ticketing.BL.DTOS.Projects;
using Bug_Ticketing.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Ticketing.BL
{
    public interface IBugManger
    {
       
        Task<List<BugReadDto>> GetAllAsynic();
        Task AddAsynic(BugAddDto bugAddDto);
        Task<BugDetailsDto> GetBugDetailsAsync(int id);
        Task<bool> AssignUserAsync(int bugId, int userId);
        Task<bool> UnassignUserAsync(int bugId, int userId);
    }
}
