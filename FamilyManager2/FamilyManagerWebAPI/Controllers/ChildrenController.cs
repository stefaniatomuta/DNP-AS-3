using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyManagerWebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace FamilyManagerWebAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ChildrenController : ControllerBase {
        private IDAO service;
        
        public ChildrenController(IDAO service) {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Child>>> GetChildrenAsync() {
            try {
                IList<Child> children = await service.GetChildrenAsync();
                return Ok(children);
            } catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("families/{streetName}/{houseNumber:int}")]
        public async Task<ActionResult<IList<Child>>> GetChildrenAsync([FromRoute] string streetName, [FromRoute] int houseNumber) {
            try {
                IList<Child> children = await service.GetChildrenAsync(streetName, houseNumber);
                return Ok(children);
            } catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{childId:int}")]
        public async Task<ActionResult<Child>> GetChildAsync([FromRoute] int childId) {
            try {
                Child child = await service.GetChildAsync(childId);
                return Ok(child);
            } catch (NullReferenceException e) {
                return NotFound(e.Message);
            } catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("families/{streetName}/{houseNumber:int}")]
        public async Task<ActionResult<Child>> AddChildAsync([FromRoute] string streetName, [FromRoute] int houseNumber, [FromBody] Child child) {
            try {
                Child newChild = await service.AddChildAsync(streetName, houseNumber, child);
                return Created($"/{child.Id}", newChild);
            } catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route("{childId:int}")]
        public async Task<ActionResult<Child>> UpdateChildAsync([FromRoute] int childId, Child child) {
            try {
                Child updatedChild = await service.UpdateChildAsync(childId, child);
                return Ok(updatedChild);
            } catch (NullReferenceException e) {
                return NotFound(e.Message);
            } catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{childId:int}")]
        public async Task<ActionResult> DeleteChildAsync([FromRoute] int childId) {
            try {
                await service.DeleteChildAsync(childId);
                return Ok();
            } catch (NullReferenceException e) {
                return NotFound(e.Message);
            } catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }
    }
}