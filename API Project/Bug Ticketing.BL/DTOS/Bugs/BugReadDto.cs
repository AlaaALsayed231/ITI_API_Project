﻿using Bug_Ticketing.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Ticketing.BL.DTOS.Bugs
{
    public class BugReadDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        
        public int ProjectId { get; set; }
        //public Project project { get; set; }
    }
}
