﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Ticketing.BL.DTOS.Users
{
    public class UserLoginDto
    {
       
        public string? Email { get; set; }
        public string? Password { get; set; }
        
    }
}
