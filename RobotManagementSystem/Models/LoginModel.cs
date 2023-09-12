using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RobotManagementSystem.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "username Required")]
        public string userName { get; set; }
       
        [Required(ErrorMessage = "password Required")]
        public string passsword { get; set; }
        //public static string name = "rutvik";
      
    }
}
