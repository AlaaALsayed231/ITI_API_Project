using Bug_Ticketing.BL.DTOS.Attachments;
using Bug_Ticketing.BL.DTOS.Bugs;
using Bug_Ticketing.BL.DTOS.Projects;
using Bug_Ticketing.DAL;
using Bug_Ticketing.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Ticketing.BL
{
    public class BugManger : IBugManger
    {
        private readonly IBugRepo _bugRepo;
        private readonly IUserRepo _userRepo;
        private readonly IUnitOfWork _unitOfWork;

        public BugManger(IBugRepo bugRepo, IUserRepo userRepo, IUnitOfWork unitOfWork)
        {
            _bugRepo = bugRepo;
            _userRepo = userRepo;
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsynic(BugAddDto bugAddDto)
        {

            var BugToAddDB = new Bug
            {
                Name = bugAddDto.Name,
                Description = bugAddDto.Description,
                ProjectId=bugAddDto.ProjectId
            };
            _unitOfWork.BugRepo.Add(BugToAddDB);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<BugDetailsDto> GetBugDetailsAsync(int id)
        {
            var bug = await _bugRepo.GetBugWithDetailsAsync(id);

            if (bug == null)
                return null;

            var bugDetailsDto = new BugDetailsDto
            {
                Id = bug.Id,
                Name = bug.Name,
                Description = bug.Description,
                ProjectId = bug.ProjectId,
                ProjectName = bug.Project?.Name,
                Attachments = bug.Attachments?.Select(a => new AttachmentDto
                {
                    Id = a.Id,
                    Path = a.Path
                }).ToList()
                
            };

            return bugDetailsDto;
        }
        public async Task<bool> AssignUserAsync(int bugId, int userId)
        {
            var bug = await _bugRepo.GetBugWithUsersAsync(bugId);
            var user = await _userRepo.GetByIdAsync(userId);

            if (bug == null || user == null || bug.Users.Any(u => u.Id == userId))
                return false;

            await _bugRepo.AssignUserToBugAsync(bug, user);
            return true;
        }

        public async Task<bool> UnassignUserAsync(int bugId, int userId)
        {
            var bug = await _bugRepo.GetBugWithUsersAsync(bugId);

            if (bug == null)
                return false;

            var user = bug.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
                return false;

            await _bugRepo.RemoveUserFromBugAsync(bug, user);
            return true;
        }

     



        public async Task<List<BugReadDto>> GetAllAsynic()
        {
            var BugFromDB = await _unitOfWork.BugRepo.GetAllAsync();
            return BugFromDB.Select(p => new BugReadDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                ProjectId=p.ProjectId
                
            }).ToList();
        }


    }
}

