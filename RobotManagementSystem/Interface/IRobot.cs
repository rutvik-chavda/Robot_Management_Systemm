using RobotManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobotManagementSystem.interFace
{
    public interface IRobot
    {
        public Task<IEnumerable<Robot>> GetRobot();
        public  Task<Robot> GetRobotById(int id);
        public Task<Responce> AddRobot(Robot robot);
        public  Task<Responce> UpdateRobot(Robot robot);
        public Task<Responce> DeleteRobot(int id);
    }
}
