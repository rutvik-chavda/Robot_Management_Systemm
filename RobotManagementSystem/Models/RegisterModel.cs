using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RobotManagementSystem.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="username Required")]
        public string UserName { get; set; }
       
        [Required(ErrorMessage = "Name Required")]
        public string FullName { get; set; }


        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile Required")]
        public string Mobile { get; set; }
        
        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }

    }
}
