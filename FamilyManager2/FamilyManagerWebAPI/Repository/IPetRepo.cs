using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace FamilyManagerWebAPI.Repository {
    public interface IPetRepo {
        Task<IList<Pet>>GetPetsAsync(string street, int number);
        Task<Pet> GetPetAsync(int id);
        Task<Pet> AddPetAsync(Pet pet, string street, int number);
        Task<Pet> AddPetAsync(Pet pet, string street, int number, int childId);
        Task<Pet> UpdatePetAsync(int id, Pet pet);
        Task RemovePetAsync(int id);
    }
}