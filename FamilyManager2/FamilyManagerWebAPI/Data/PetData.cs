using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace FamilyManagerWebAPI.Data {
    public class PetData : IPetData {
        public async Task<Pet> GetPetAsync(int petId) {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Pet>> GetPetsAsync(string street, int number) {
            throw new System.NotImplementedException();
        }

        public async Task<Pet> AddPetAsync(Pet pet, string street, int number) {
            throw new System.NotImplementedException();
        }

        public async Task<Pet> AddPetAsync(Pet pet, string street, int number, int childId) {
            throw new System.NotImplementedException();
        }

        public async Task<Pet> RemovePetAsync(int petId) {
            throw new System.NotImplementedException();
        }

        public async Task<Pet> UpdatePetAsync(int id, Pet pet) {
            throw new System.NotImplementedException();
        }
    }
}