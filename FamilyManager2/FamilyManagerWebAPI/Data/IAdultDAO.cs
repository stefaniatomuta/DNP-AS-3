using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace FamilyManagerWebAPI.Data {
    public interface IAdultDAO {
        Task<Adult> AddAdultAsync(string streetName, int houseNumber, Adult adult);
        Task<Adult> GetAdultByFamilyAsync(string streetName, int houseNumber, int id);
        Task<Adult> GetAdultAsync(int id);
        Task DeleteAdultAsync(int id);
        
        Task<Adult> UpdateAdultAsync(int id);
        Task<IList<Adult>> GetAdultsAsync();

    }
}