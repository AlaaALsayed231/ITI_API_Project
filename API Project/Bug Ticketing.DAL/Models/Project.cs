﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Ticketing.DAL.Models
{
    public class Project
    {
     public int Id { get; set; }
     public string? Name { get; set; }
     public string? Description { get; set; }
     public ICollection<Bug> Bugs { get; set; }

    }
}
