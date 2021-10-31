using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace FamilyManagerWebAPI.Data {
    public interface IAdultDAO {
        Task<IList<Adult>> GetAdultsAsync();
        Task<Adult> GetAdultAsync(int id);
        Task<IList<Adult>> GetAdultsByFamilyAsync(string streetName, int houseNumber);
        Task<Adult> AddAdultAsync(string streetName, int houseNumber, Adult adult);
        Task<Adult> UpdateAdultAsync(int id, Adult adult);
        Task DeleteAdultAsync(int id);
    }
}