using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace FamilyManagerWebAPI.Data {
    public interface IFamilyData {
        
        
        //Get
        Task<IList<Family>> GetFamiliesAsync();
        Task<IList<Person>> GetPeopleAsync();
        Task<Family> GetFamilyAsync(string streetName, int houseNumber);
        Task<Person> GetPersonByIdFirstLastNameAsync(int id, string firstname, string lastname);
        Task<IList<string>> GetEyeColorsAsync();
        Task<IList<string>> GetHairColorsAsync();
        Task<IList<Adult>> GetAdultsAsync();
        Task<IList<Child>> GetChildrenAsync();
        Task<Person> GetPersonAsync();

        //Add
        Task<Family> AddFamilyAsync(Family family);
        Task<Adult> AddAdultAsync(Adult adult, Family family);
        Task<Child> AddChildAsync(Child child, Family family);
        

        //Remove
        Task<Family> RemoveFamilyAsync(string streetName, int houseNumber);
        Task<Person> RemovePersonAsync(int id, string streetName, int houseNumber);
        

        
        //Update
        Task<Family> UpdateFamilyAsync(Family family);
        Task<Person> UpdatePersonAsync(Person person);
        
        //update family, person, pet

    }
}