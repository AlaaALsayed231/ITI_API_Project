using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Ticketing.DAL.Models
{
    public class Attachment
    {
        public int Id { get; set; }
        public String? Path { get; set; }

        public int BugId { get; set; }
        public Bug? Bug { get; set; }
    }
}
