using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Ticketing.DAL.Models
{
    public class Bug
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        //[ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public ICollection<Attachment>Attachments { get; set; }
        public ICollection<User> Users { get; set; }



    }
}
