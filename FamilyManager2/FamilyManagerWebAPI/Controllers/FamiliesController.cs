using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyManagerWebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace FamilyManagerWebAPI.Controllers {
    
    [ApiController]
    [Route("[controller]")]
    public class FamiliesController : ControllerBase {
        
        public IDAO FamilyData { get; }

        public FamiliesController(IDAO familyData) {
            FamilyData = familyData;
        }

        //methods
        [HttpGet]
        public async Task<ActionResult<IList<Family>>> GetFamiliesAsync() {
            try {
                IList<Family> families = await FamilyData.GetFamiliesAsync();
                return Ok(families);
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{streetName}/{houseNumber:int}")]
        public async Task<ActionResult<Family>> GetFamilyAsync([FromRoute] string streetName, [FromRoute] int houseNumber) {
            try {
                Family family = await FamilyData.GetFamilyAsync(streetName, houseNumber);
                return Ok(family);
            }
            catch (NullReferenceException e) {
                return NotFound();
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Family>> AddFamilyAsync([FromBody] Family family) {
            try {
                Family familyAdded = await FamilyData.AddFamilyAsync(family);
                return Created($"/{familyAdded.GetUniqueKey()}", familyAdded);
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route("{streetName}/{houseNumber:int}")]
        public async Task<ActionResult<Family>> UpdateFamilyAsync([FromBody] Family family, [FromRoute] string streetName, [FromRoute] int houseNumber) {
            try {
                Family editedFamily = await FamilyData.UpdateFamilyAsync(streetName, houseNumber,family);
                return Ok(editedFamily);
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{streetName}/{houseNumber:int}")]
        public async  Task<ActionResult<Family>> RemoveFamilyAsync([FromRoute] string streetName, [FromRoute] int houseNumber) {
            try {
                Family removedFamily = await FamilyData.RemoveFamilyAsync(streetName, houseNumber);
                return Ok(removedFamily);
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }
        
        
    }
}