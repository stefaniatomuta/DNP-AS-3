using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyManagerWebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace FamilyManagerWebAPI.Controllers {
    
    [ApiController]
    [Route("[controller]")]
    public class FamiliesController {
        
        public IFamilyData FamilyData { get; }

        public FamiliesController(IFamilyData familyData) {
            FamilyData = familyData;
        }

        //methods
        [HttpGet]
        public async Task<ActionResult<IList<Family>>> GetFamiliesAsync() {
            try {
                IList<Family> families = await FamilyData.GetFamiliesAsync();
            }
        }
        
        
    }
}