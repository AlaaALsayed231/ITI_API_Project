﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Ticketing.BL.DTOS.Bugs
{
    public class BugAddDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int ProjectId { get; set; }
    }
}
