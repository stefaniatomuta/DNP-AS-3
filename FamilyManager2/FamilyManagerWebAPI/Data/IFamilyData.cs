using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace FamilyManagerWebAPI.Data {
    public interface IFamilyData {
        
        
        //Get
        
        Task<Person> GetPersonByIdFirstLastNameAsync(int id, string firstname, string lastname);
        Task<Pet> GetPetAsync(int petId);
        Task<IList<string>> GetEyeColorsAsync();
        Task<IList<string>> GetHairColorsAsync();
        Task<IList<Adult>> GetAdultsAsync();
        Task<IList<Child>> GetChildrenAsync();
        Task<IList<Pet>> GetPetsAsync();
        Task<Person> GetPersonAsync();

        //Add
       
        Task<Adult> AddAdultAsync(Adult adult, Family family);
        Task<Child> AddChildAsync(Child child, Family family);
        Task<Pet> AddPetAsync(Pet pet, Family family);
        Task<Pet> AddPetAsync(Pet pet, Family family, Child child);

        //Remove
        
        Task<Person> RemovePersonAsync(int id, string streetName, int houseNumber);
        Task<Pet> RemovePetAsync(int petId, string streetName, int houseNumber);

        
        //Update
        
        Task<Person> UpdatePersonAsync(Person person);
        Task<Pet> UpdatePetAsync(Pet pet);
        //update family, person, pet

    }
}