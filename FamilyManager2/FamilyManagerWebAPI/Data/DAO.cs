using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Pet> GetPetAsync(int petId) {
            return file.Pets.First(p => petId == p.Id);
        }

        public async Task<IList<Pet>> GetPetsAsync(string street, int number) {
            return file.Families.First(f => f.StreetName.Equals(street) && f.HouseNumber == number).Pets;
        }

        public async Task<Pet> AddPetAsync(Pet pet, string street, int number) {
            file.Families.First(f => f.StreetName.Equals(street) && f.HouseNumber == number).Pets.Add(pet);
            return pet;
        }

        public async Task<Pet> AddPetAsync(Pet pet, string street, int number, int childId) {
            file.Families.First(f => f.StreetName.Equals(street) && f.HouseNumber == number).Children.First(c => c.Id == childId).Pets.Add(pet);
            return pet;
        }

        public async Task<Pet> UpdatePetAsync(int id, Pet pet) {
            Pet p = file.Pets.First(p => p.Id == id);
            p.Age = pet.Age;
            p.Name = pet.Name;
            p.Species = pet.Species;
            return p;
        }

        public async Task RemovePetAsync(int petId) {
            foreach (var pet in file.Pets) {
                if (pet.Id == petId)
                    file.Pets.Remove(pet);
            }
        }
    }
}