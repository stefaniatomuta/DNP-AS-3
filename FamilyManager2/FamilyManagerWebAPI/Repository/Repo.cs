using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyManagerWebAPI.Data;
using Models;

namespace FamilyManagerWebAPI.Repository {
    public class Repo : IFamilyRepo,IPeopleRepo,IAdultRepo, IStatisticRepo, IChildRepo, IPetRepo {
        private IDAO Dao;

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

        // Children repo methods
        public async Task<IList<Child>> GetChildrenAsync() {
            return await Dao.GetChildrenAsync();
        }

        public async Task<IList<Child>> GetChildrenAsync(string streetName, int houseNumber) {
            return await Dao.GetChildrenAsync(streetName, houseNumber);
        }

        public async Task<Child> GetChildAsync(int childId) {
            return await Dao.GetChildAsync(childId);
        }

        public async Task<Child> AddChildAsync(string streetName, int houseNumber, Child child) {
            return await Dao.AddChildAsync(streetName, houseNumber, child);
        }

        public async Task<Child> UpdateChildAsync(int childId, Child child) {
            return await Dao.UpdateChildAsync(childId, child);
        }

        public async Task DeleteChildAsync(int childId) {
            await Dao.DeleteChildAsync(childId);
        }

        // Pets repo methods
        public async Task<IList<Pet>> GetPetsAsync(string street, int number) {
            return await Dao.GetPetsAsync(street, number);
        }

        public async Task<Pet> GetPetAsync(int id) {
            return await Dao.GetPetAsync(id);
        }

        public async Task<Pet> AddPetAsync(Pet pet, string street, int number) {
            return await Dao.AddPetAsync(pet, street, number);
        }

        public async Task<Pet> AddPetAsync(Pet pet, string street, int number, int childId) {
            return await Dao.AddPetAsync(pet, street, number, childId);
        }

        public async Task<Pet> UpdatePetAsync(int id, Pet pet) {
            return await Dao.UpdatePetAsync(id, pet);
        }

        public async Task RemovePetAsync(int id) {
            await Dao.RemovePetAsync(id);
        }
    }
}