using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RobotManagementSystem.Models
{
    public class Robot
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string robotName { get; set; }

        [Required]
        public string ownerName { get; set; }
        [Required]
        public string location { get; set; }
        //[Required]
        //public DateTime lastActive { get; set; }
        [Required]
        public float firmwareVersion { get; set; }
    }
}
