using System.Collections;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FamilyManagerWebAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class PetsController : ControllerBase {

        [HttpGet]
        public async Task<ActionResult<IList<Pet>>>()
    }
}