using System;
using System.Threading.Tasks;
using FamilyManagerWebAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace FamilyManagerWebAPI.Controllers {
    
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase {
        
        private IDAO service;

        public DataController(IDAO service) {
            this.service = service;
        }

        [HttpGet]
        [Route("eyecolors")]
        public async Task<ActionResult<string>> GetEyeColorsAsync() {
            try {
                return Ok(await service.GetEyeColorsAsync());
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        [Route("haircolors")]
        public async Task<ActionResult<string>> GetHairColorsAsync() {
            try {
                return Ok(await service.GetHairColorsAsync());
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }
    }
}