using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace FamilyManagerWebAPI.Repository {
    public interface IChildRepo {
        Task<IList<Child>> GetChildrenAsync();
        Task<IList<Child>> GetChildrenAsync(string streetName, int houseNumber);
        Task<Child> GetChildAsync(int childId);
        Task<Child> AddChildAsync(string streetName, int houseNumber, Child child);
        Task<Child> UpdateChildAsync(int childId, Child child);
        Task DeleteChildAsync(int childId);
    }
}