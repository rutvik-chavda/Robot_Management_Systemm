using Microsoft.EntityFrameworkCore;
using RobotManagementSystem.Dbcontext;
using RobotManagementSystem.interFace;
using RobotManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobotManagementSystem.Repos
{
    public class RobotRepo:IRobot
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public RobotRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        //get
        public async Task<IEnumerable<Robot>> GetRobot()
        {
            IEnumerable<Robot> c = (IEnumerable<Robot>)await _applicationDbContext.Robots.ToListAsync();
            if (c != null)
                return c;
            return null;

        }

        //getbyid
        public async Task<Robot> GetRobotById(int id)
        {
            Robot r = await _applicationDbContext.Robots.FirstOrDefaultAsync(e => e.Id == id);

            if (r != null)
                return r;
            return null;
        }

        //add
        public async Task<Responce> AddRobot(Robot robot)
        {
            Robot existingRobot = await _applicationDbContext.Robots.FirstOrDefaultAsync(r => r.robotName.ToLower() == robot.robotName.ToLower());
            if (existingRobot != null)
            {
                return new Responce { Status = "Error", Message = "Robot Name already exists" };
            }
            await _applicationDbContext.Robots.AddAsync(robot);
            await _applicationDbContext.SaveChangesAsync();
            return new Responce { Status = "Success", Message = "Robot added successfully" };
        }

        //update
        public async Task<Responce> UpdateRobot(Robot robot)
        {
            if (robot == null)
            {
                return new Responce { Status = "Error", Message = "Invalid Robot" };
            }
            Robot rob = await _applicationDbContext.Robots.FirstOrDefaultAsync(r => r.Id == robot.Id);
            if (rob != null)
            {

                Robot existingRobot = await _applicationDbContext.Robots.FirstOrDefaultAsync(r => r.robotName.ToLower() == robot.robotName.ToLower());
                if (existingRobot == null)
                {
                    _applicationDbContext.ChangeTracker.Clear();
                    _applicationDbContext.Robots.Update(robot);
                    await _applicationDbContext.SaveChangesAsync();
                    return new Responce { Status = "Success", Message = "Robot updated successfully" };
                }
                existingRobot = await _applicationDbContext.Robots.FirstOrDefaultAsync(r => r.robotName.ToLower() == robot.robotName.ToLower() && r.Id == robot.Id);
                if (existingRobot != null)
                {
                    _applicationDbContext.ChangeTracker.Clear();
                    _applicationDbContext.Robots.Update(robot);
                    await _applicationDbContext.SaveChangesAsync();
                    return new Responce { Status = "Success", Message = "Robot updated successfully" };
                }
                return new Responce { Status = "Error", Message = "Robot Name Alrady exists" };
            }
            return new Responce { Status = "Error", Message = "Robot not found" };
        }
        
        //delete
        public async Task<Responce> DeleteRobot(int id)
        {
            Robot r = await _applicationDbContext.Robots.FirstOrDefaultAsync(r => r.Id == id);
            if (r == null)
            {
                return new Responce { Status = "Error", Message = "Robot category" };
            }
            _applicationDbContext.Robots.Remove(r);
            await _applicationDbContext.SaveChangesAsync();
            return new Responce { Status = "Success", Message = "Robot Deleted successfully" };


        }
    }
}
