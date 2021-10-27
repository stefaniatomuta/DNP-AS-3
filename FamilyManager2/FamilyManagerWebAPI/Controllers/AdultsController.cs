using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace FamilyManagerWebAPI.Controllers {
    
    [ApiController]
    [Route("families/{streetName}/{houseNumber:int}/[controller]")]
    public class AdultsController : ControllerBase {

        [HttpGet]
        public async Task<ActionResult<Adult>> GetAdultsAsync([FromRoute] string streetName, [FromRoute] int houseNumber) {
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
                Adult adult = await service.GetAdultsAsyncById(adultId);
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


    }
}