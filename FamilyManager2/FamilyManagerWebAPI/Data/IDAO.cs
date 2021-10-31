using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace FamilyManagerWebAPI.Data {
    public interface IDAO : IFamilyDAO, IAdultDAO, IChildDAO {
        Task<IList<string>> GetEyeColorsAsync();
        Task<IList<string>> GetHairColorsAsync();
        Task<IList<Pet>>GetPetsAsync(string street, int number);
        Task<Pet> GetPetAsync(int id);
        Task<Pet> AddPetAsync(Pet pet, string street, int number);
        Task<Pet> AddPetAsync(Pet pet, string street, int number, int childId);
        Task<Pet> UpdatePetAsync(int id, Pet pet);
        Task RemovePetAsync(int id);
        Task<IList<Person>> GetPeopleAsync();
        Task<Person> GetPersonAsync(int id, string firstName, string lastName);
    }
}