﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.User.Entities
{
    public class Admin : Person
    {
        public Admin()
        {
            Role = Enums.Role.Admin;
        }
    }
}
