using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace FamilyManagerWebAPI.Repository {
    public interface IPeopleRepo {
        Task<IList<Person>> GetPeopleAsync();
        Task<Person> GetPersonAsync(int id, string firstName, string lastName);
    }
}