using Bug_Ticketing.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Ticketing.BL.DTOS.Projects
{
    public class ProjectReadDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        //public ICollection<BugDto> Bugs { get; set; }
    }

   // public class BugDto
   // {
   //public string Id { get; set; }
   //     public string Name { get; set; }
   //     public string? Description { get; set; }
   // }
}
