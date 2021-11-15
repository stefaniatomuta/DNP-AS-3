using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyManagerWebAPI.Data;
using Models;

namespace FamilyManagerWebAPI.Repository {
    public class Repo : IFamilyRepo,IPeopleRepo,IAdultRepo, IStatisticRepo {
        public IDAO Dao;

        public Repo() {
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
        //Adult repo methods
        public async Task<IList<Adult>> GetAdultsAsync() {
            return await Dao.GetAdultsAsync();
        }

        public async Task<Adult> GetAdultAsync(int id) {
            return await Dao.GetAdultAsync(id);
        }

        public async Task<IList<Adult>> GetAdultsByFamilyAsync(string streetName, int houseNumber) {
            return await Dao.GetAdultsByFamilyAsync(streetName, houseNumber);
        }

        public async Task<Adult> AddAdultAsync(string streetName, int houseNumber, Adult adult) {
            return await Dao.AddAdultAsync(streetName, houseNumber, adult);
        }

        public async Task<Adult> UpdateAdultAsync(int id, Adult adult) {
            return await Dao.UpdateAdultAsync(id, adult);
        }

        public async Task DeleteAdultAsync(int id) {
            await Dao.DeleteAdultAsync(id);
        }

        //Statistic repo
        public async Task<IList<string>> GetEyeColorsAsync() {
            return await Dao.GetEyeColorsAsync();
        }

        public async Task<IList<string>> GetHairColorsAsync() {
            return await Dao.GetHairColorsAsync();
        }
    }
}