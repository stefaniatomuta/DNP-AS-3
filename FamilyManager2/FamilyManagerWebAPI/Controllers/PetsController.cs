using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyManagerWebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace FamilyManagerWebAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class PetsController : ControllerBase {
        private IPetData service;

        public PetsController(IPetData service) {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Pet>>> GetPetsAsync([FromRoute] string street, [FromRoute] int number) {
            try {
                IList<Pet> pets = await service.GetPetsAsync(street, number);
                return Ok(pets);
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Pet>> getPetAsync([FromRoute] int id) {
            try {
                Pet pet = await service.GetPetAsync(id);
                return Ok(pet);
            }
            catch (NullReferenceException e) {
                return NotFound(e.Message);
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("families/{street}/{number:int}")]
        public async Task<ActionResult<Pet>> AddPetAsync([FromRoute] Pet pet, [FromRoute] string street, [FromRoute] int number) {
            try {
                Pet newPet = await service.AddPetAsync(pet, street, number);
                return Created($"{pet.Id}", newPet);
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("families/{street}/{number:int}/children/{childId:int}")]
        public async Task<ActionResult<Pet>> AddPetAsync([FromRoute] Pet pet, [FromRoute] string street, [FromRoute] int number, [FromRoute] int childId) {
            try {
                Pet newPet = await service.AddPetAsync(pet, street, number, childId);
                return Created($"{pet.Id}", newPet);
            }
            catch (NullReferenceException e) {
                return NotFound(e.Message);
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route ("{id:int}")]
        public async Task<ActionResult<Pet>> UpdatePetAsync([FromRoute] int id,[FromBody] Pet pet) {
            try {
                Pet updated = await service.UpdatePetAsync(id, pet);
                return Ok(updated);
            }
            catch (NullReferenceException e) {
                return NotFound(e.Message);
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Pet>> DeletePetAsync([FromRoute] int id) {
            try {
                await service.RemovePetAsync(id);
                return Ok();
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