using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyManagerWebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace FamilyManagerWebAPI.Controllers {
    
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase {
        private IDAO service;
        
        public PeopleController(IDAO service) {
            this.service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult<IList<Person>>> GetPeopleAsync() {
            try {
                IList<Person> people = await service.GetPeopleAsync();
                return Ok(people);
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Person>> GetPersonAsync([FromRoute] int id, [FromQuery] string? firstName, [FromQuery] string? lastName) {
            if (firstName == null || lastName == null) return BadRequest("Please enter a first- and last name");
            try {
                Person person = await service.GetPersonAsync(id, firstName, lastName);
                return Ok(person);
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