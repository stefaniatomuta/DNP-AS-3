using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyManagerWebAPI.Data;
using Models;

namespace FamilyManagerWebAPI.Repository {
    public class FamilyRepo : IFamilyRepo,IPeopleRepo {
        public IDAO Dao;

        public FamilyRepo() {
            Dao = new DAO();
        }

        //Family repo methods
        public async Task<IList<Family>> GetFamiliesAsync() {
             return await Dao.GetFamiliesAsync();
        }

        public async Task<Family> GetFamilyAsync(string streetName, int houseNumber) {
            return await Dao.GetFamilyAsync(streetName, houseNumber);
        }

        public async Task<Family> AddFamilyAsync(Family family) {
            return await Dao.AddFamilyAsync(family);
        }

        public async Task<Family> RemoveFamilyAsync(string streetName, int houseNumber) {
            return await Dao.RemoveFamilyAsync(streetName, houseNumber);
        }

        public async Task<Family> UpdateFamilyAsync(string streetName, int houseNumber, Family family) {
            return await Dao.UpdateFamilyAsync(streetName, houseNumber, family);
        }
        
        //People repo methods
        public async Task<IList<Person>> GetPeopleAsync() {
            return await Dao.GetPeopleAsync();
        }

        public async Task<Person> GetPersonAsync(int id, string firstName, string lastName) {
            return await Dao.GetPersonAsync(id, firstName, lastName);
        }
    }
}