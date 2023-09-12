using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RobotManagementSystem.interFace;
using RobotManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobotManagementSystem.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RobotController : ControllerBase
    {
        private readonly IRobot _robot;
        public RobotController(IRobot robot)
        {
            _robot = robot;
        }
        [HttpPost]
        [Route("AddRobot")]
        public async Task<ActionResult<Responce>> AddRobot(Robot r)
        {
            return (r == null) ? BadRequest() : Ok(await _robot.AddRobot(r));
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("GetRobot")]
        public async Task<ActionResult<IEnumerable<Robot>>> GetRobot()
        {
            IEnumerable<Robot> r = await _robot.GetRobot();
            if (r.Count() == 0)
                return NotFound();
            return Ok(r);
        }
        [HttpDelete]
        [Route("DeleteRobot")]
        public async Task<IActionResult> DeleteRobot(int id)
        {
            return Ok(await _robot.DeleteRobot(id));
        }
        [HttpGet]
        [Route("getRobotid")]
        public async Task<ActionResult<Robot>> GetRobotById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            Robot c = await _robot.GetRobotById(id);
            if (c == null)
                return NotFound();
            return Ok(c);
        }
        [HttpPut]
        [Route("UpdateRobot")]
        public async Task<IActionResult> UpdateCategory(Robot r)
        {
            return Ok(await _robot.UpdateRobot(r));
        }

    }
}
