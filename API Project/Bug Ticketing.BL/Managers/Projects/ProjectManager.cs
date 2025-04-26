using Bug_Ticketing.BL.DTOS.Projects;
using Bug_Ticketing.DAL;
using Bug_Ticketing.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Ticketing.BL.Managers.Projects
{
    public class ProjectManager : IProjectManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(ProjectAddDto projectAddDto)
        {
            var ProjectToAddDB = new Project
            {
                Name = projectAddDto.Name,
                Description=projectAddDto.Descripton
            };
            _unitOfWork.ProjectRepo.Add(ProjectToAddDB);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ProjectReadDto>> GetAllAsynic()
        {
            var ProjectFromDB = await _unitOfWork.ProjectRepo.GetAllAsync();
            return ProjectFromDB.Select(p => new ProjectReadDto
            {
                Id = p.Id,
                Name = p.Name,
                Description=p.Description
            }).ToList();
        }

        public async Task<ProjectDetailsDto?> GetProjectWithBugsAsync(int id)
        {
            var Project = await _unitOfWork.ProjectRepo.GetProjectWithBugsAsync(id);
            if (Project == null)
            {
                return null;
            }
            return new ProjectDetailsDto
            {
                Id = Project.Id,
                Name = Project.Name,
                Description = Project.Description,
                Bugs = Project.Bugs.Select(b => new BugDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    Description = b.Description
                }).ToList()

            };
                
        }
    }
}
