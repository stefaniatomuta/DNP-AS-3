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
        private IDAO service;
        
        public AdultsController(IDAO familyData) {
           service = familyData;
        }
        
        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdultsAsync() {
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
        [Route("{streetName}/{houseNumber:int}")]
        public async Task<ActionResult<IList<Adult>>> GetAdultsByFamily([FromRoute] string streetName, [FromRoute] int houseNumber) {
            try {
                IList<Adult> adult1 = await service.GetAdultsByFamilyAsync(streetName, houseNumber);
                return Ok(adult1);
            }
            catch (NullReferenceException e) {
                return NotFound(e.Message);
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("{streetName}/{houseNumber:int}")]
        public async Task<ActionResult<Adult>> AddAdult([FromRoute] string streetName, [FromRoute] int houseNumber,
            [FromBody] Adult adult) {
            try {
                Adult adult1 = await service.AddAdultAsync(streetName, houseNumber, adult);
                return Created($"/{adult.Id}", adult1);
            }
            catch (Exception e) {
                Console.WriteLine(e.StackTrace);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteAdult([FromRoute] int id) {
            try {
                await service.DeleteAdultAsync(id);
                return Ok();
            } catch (NullReferenceException e) {
                return NotFound(e.Message);
            } catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> UpdateAdult([FromRoute] int id, [FromBody] Adult adult) {
            try {
                Adult updated = await service.UpdateAdultAsync(id, adult);
                return Ok(updated);
            } catch (NullReferenceException e) {
                return NotFound(e.Message);
            } catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }
    }
}