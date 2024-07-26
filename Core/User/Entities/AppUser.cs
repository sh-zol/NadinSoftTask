using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.User.Entities
{
    public class AppUser:IdentityUser<int>
    {
        public Admin? Admin { get; set; }
        public Customer? Customer { get; set; }
        public Manufacturer? Manufacturer { get; set; }
    }
}
