using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyManagerWebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace FamilyManagerWebAPI.Controllers {
    
    [ApiController]
    [Route("[controller]")]
    public class AdultsController : ControllerBase {
        private IAdultDAO service;
        public AdultsController(IAdultDAO familyData) {
           service = familyData;
        }
        [HttpGet]
        public async Task<ActionResult<Adult>> GetAdultsAsync() {
            try {
                IList<Adult> adults = await service.GetAdultsAsync();
                return Ok(adults);
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{adultId:int}")]
        public async Task<ActionResult<Adult>> GetAdult([FromRoute] int adultId) {
            try {
                Adult adult = await service.GetAdultAsync(adultId);
                return Ok(adult);
            }
            catch (NullReferenceException e) {
                return NotFound(e.Message);
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        [Route("families/{streetName}/{houseNumber:int}")]
        public async Task<ActionResult<Adult>> GetAdultByFamily([FromRoute] string streetName, [FromRoute] int houseNumber,
            [FromBody] Adult adult) {
            try {
                Adult adult1 = await service.GetAdultByFamilyAsync(streetName, houseNumber, adult.Id);
                return Ok(adult);
            }
            catch (NullReferenceException e) {
                return NotFound(e.Message);
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("families/{streetName}/{houseNumber:int}")]
        public async Task<ActionResult<Adult>> AddAdult([FromRoute] string streetName, [FromRoute] int houseNumber,
            [FromBody] Adult adult) {
            try {
                Adult adult1 = await service.AddAdultAsync(streetName, houseNumber, adult);
                return Created($"/{adult.Id}", adult1);
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteAdult([FromRoute] int id) {
            try {
                await service.DeleteAdultAsync(id);
                return Ok();
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPatch]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> UpdateToDo([FromBody] int id) {
            try {
                Adult updated = await service.UpdateAdultAsync(id);
                return Ok(updated);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
        }

    }
}