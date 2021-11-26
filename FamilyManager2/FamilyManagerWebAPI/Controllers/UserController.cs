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
        private IUserDAO userDao;

        public UserController(IUserDAO userDao) {
            this.userDao = userDao;
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetUserAsync([FromQuery] string? username, [FromQuery] string? password) {
            try {
                if (username == null || password == null) return BadRequest("Please enter username and password");
                
                User user = await userDao.GetUserAsync(username, password);
                return Ok(user);
            }
            catch (NullReferenceException e) {
                return NotFound(e.Message);
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUserAsync([FromBody] User user) {
            try {
                User newUser = await userDao.AddUserAsync(user);
                return Created($"/{newUser.Username}", newUser);
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route("{username}")]
        public async Task<ActionResult<User>> UpdateUserAsync([FromRoute] string username, [FromBody] User user) {
            try {
                User u = await userDao.UpdateUserAsync(username, user);
                return Ok(u);
            }
            catch (NullReferenceException e) {
                return NotFound(e.Message);
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }
    }
}