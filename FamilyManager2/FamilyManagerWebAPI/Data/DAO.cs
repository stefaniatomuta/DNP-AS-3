using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace FamilyManagerWebAPI.Data {
    public class DAO : IDAO {
        private FileContext file;
        
        public DAO() {
            file = new FileContext();
        }

        public async Task<IList<string>> GetEyeColorsAsync() {
            throw new System.NotImplementedException();
        }

        public async Task<IList<string>> GetHairColorsAsync() {
            throw new System.NotImplementedException();
        }


        public async Task<IList<Family>> GetFamiliesAsync() {
            List<Family> families = new List<Family>(file.Families);
            return families;
        }

        public Task<Family> GetFamilyAsync(string streetName, int houseNumber) {
            throw new System.NotImplementedException();
        }

        public Task<Family> AddFamilyAsync(Family family) {
            throw new System.NotImplementedException();
        }

        public Task<Family> RemoveFamilyAsync(string streetName, int houseNumber) {
            throw new System.NotImplementedException();
        }

        public Task<Family> UpdateFamilyAsync(Family family) {
            throw new System.NotImplementedException();
        }

        public Task<Adult> AddAdultAsync(string streetName, int houseNumber, Adult adult) {
            throw new System.NotImplementedException();
        }

        public Task<Adult> GetAdultByFamilyAsync(string streetName, int houseNumber, int id) {
            throw new System.NotImplementedException();
        }

        public Task<Adult> GetAdultAsync(int id) {
            throw new System.NotImplementedException();
        }

        public Task DeleteAdultAsync(int id) {
            throw new System.NotImplementedException();
        }

        public Task<Adult> UpdateAdultAsync(int id) {
            throw new System.NotImplementedException();
        }

        public Task<IList<Adult>> GetAdultsAsync() {
            throw new System.NotImplementedException();
        }

        public Task<IList<Child>> GetChildrenAsync() {
            throw new System.NotImplementedException();
        }

        public Task<IList<Child>> GetChildrenAsync(string streetName, int houseNumber) {
            throw new System.NotImplementedException();
        }

        public Task<Child> GetChildAsync(int childId) {
            throw new System.NotImplementedException();
        }

        public Task<Child> AddChildAsync(string streetName, int houseNumber, Child child) {
            throw new System.NotImplementedException();
        }

        public Task<Child> UpdateChildAsync(int childId, Child updatedChild) {
            throw new System.NotImplementedException();
        }

        public Task DeleteChildAsync(int childId) {
            throw new System.NotImplementedException();
        }

        public Task<Pet> GetPetAsync(int petId) {
            throw new System.NotImplementedException();
        }

        public Task<IList<Pet>> GetPetsAsync(string street, int number) {
            throw new System.NotImplementedException();
        }

        public Task<Pet> AddPetAsync(Pet pet, string street, int number) {
            throw new System.NotImplementedException();
        }

        public Task<Pet> AddPetAsync(Pet pet, string street, int number, int childId) {
            throw new System.NotImplementedException();
        }

        public Task<Pet> RemovePetAsync(int petId) {
            throw new System.NotImplementedException();
        }

        public Task<Pet> UpdatePetAsync(int id, Pet pet) {
            throw new System.NotImplementedException();
        }
    }
}