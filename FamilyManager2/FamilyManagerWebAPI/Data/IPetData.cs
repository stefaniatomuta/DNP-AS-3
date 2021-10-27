using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace FamilyManagerWebAPI.Data {
    public interface IPetData {
        Task<Pet> GetPetAsync(int petId);
        Task<IList<Pet>> GetPetsAsync(string street, int number);
        Task<Pet> AddPetAsync(Pet pet, string street, int number);
        Task<Pet> AddPetAsync(Pet pet, string street, int number, int childId);
        Task<Pet> RemovePetAsync(int petId);
        Task<Pet> UpdatePetAsync(int id, Pet pet);
    }
}