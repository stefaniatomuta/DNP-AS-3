using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace FamilyManagerWebAPI.Repository {
    public interface IFamilyRepo {
        Task<IList<Family>> GetFamiliesAsync();
        Task<Family> GetFamilyAsync(string streetName, int houseNumber);
        Task<Family> AddFamilyAsync(Family family);
        Task<Family> RemoveFamilyAsync(string streetName, int houseNumber);
        Task<Family> UpdateFamilyAsync(string streetName, int houseNumber, Family family);
    }
}