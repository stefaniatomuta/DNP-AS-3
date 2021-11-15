using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyManagerWebAPI.Data;
using FamilyManagerWebAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace FamilyManagerWebAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase {
        private IUserRepo userRepo;

        public UserController(IUserRepo userRepo) {
            this.userRepo = userRepo;
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetUserAsync([FromQuery] string? username, [FromQuery] string? password) {
            try {
                if (username == null || password == null) return BadRequest("Please enter username and password");
                
                User user = await userRepo.GetUserAsync(username, password);
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
                User newUser = await userRepo.AddUserAsync(user);
                return Created($"/{newUser.Username}", newUser);
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }
    }
}