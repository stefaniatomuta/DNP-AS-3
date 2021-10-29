using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyManagerWebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace FamilyManagerWebAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase {
        public IUserDAO UserDao;

        public UserController(IUserDAO userDao) {
            UserDao = userDao;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUserAsync([FromQuery] string? username, [FromQuery] string? password) {
            try {
                if (username == null || password == null)
                    return BadRequest("No user found");
                User users = await UserDao.GetUserAsync(username, password);
                return Ok(users);
            }
            catch (NullReferenceException e) {
                return NotFound(e.Message);
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUserAsync([FromBody] User user) {
            try {
                User newUser = await UserDao.AddUserAsync(user);
                return Created($"/{newUser.Username}", newUser);
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }
    }
}