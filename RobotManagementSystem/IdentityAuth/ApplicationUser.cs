using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobotManagementSystem.IdentityAuth
{
    public class ApplicationUser:IdentityUser
    {
        public Boolean Isadmin { get; set; }
        public String Fullname { get; set; }
    }
}
