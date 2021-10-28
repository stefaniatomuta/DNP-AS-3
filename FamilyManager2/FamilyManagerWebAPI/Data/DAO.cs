using System;
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
        public async Task<IList<Adult>> GetAdultsByFamilyAsync(string streetName, int houseNumber) {
            return file.Families.First(f => f.StreetName.Equals(streetName) && f.HouseNumber == houseNumber).Adults;
        }
        
        public async Task<Adult> GetAdultAsync(int id) {
            IList<Adult> adults = await GetAdultsAsync();
            return adults.FirstOrDefault(adult => adult.Id == id);
        }

        public async Task DeleteAdultAsync(int id) {
            IList<Adult> adults = await GetAdultsAsync();
            Adult adult = adults.FirstOrDefault(adult => adult.Id == id);
            adults.Remove(adult);
        }

        public async Task<Adult> UpdateAdultAsync(int id, Adult a) {
            IList<Adult> adults = await GetAdultsAsync();
            Adult adult = adults.FirstOrDefault(adult => adult.Id == id);
            adult.FirstName = a.FirstName;
            adult.LastName = a.LastName;
            adult.HairColor = a.HairColor;
            adult.JobTitle = a.JobTitle;
            adult.Age = a.Age;
            adult.Height = a.Height;
            adult.Weight = a.Weight;
            adult.EyeColor = a.EyeColor;
            return adult;
        }

        public async Task<IList<Adult>> GetAdultsAsync() {
            IList<Adult> adults = new List<Adult>();
            foreach (var family in file.Families) {
                foreach (Adult adult in family.Adults) {
                    adults.Add(adult);
                }
            }
            return adults;
        }

        public async Task<IList<Child>> GetChildrenAsync() {
            IList<Child> children = new List<Child>();
            foreach (Person p in file.People) {
                if (p is Child child) {
                    children.Add(child);
                }
            }
            return children;
        }

        public async Task<IList<Child>> GetChildrenAsync(string streetName, int houseNumber) {
            Family family = file.Families.FirstOrDefault(f => f.StreetName.Equals(streetName) && f.HouseNumber == houseNumber);
            if (family == null) throw new NullReferenceException("No such family found");
            return family.Children;
        }

        public async Task<Child> GetChildAsync(int childId) {
            Child child = (await GetChildrenAsync()).FirstOrDefault(c => c.Id == childId);
            if (child == null) throw new NullReferenceException("No such child found");
            return child;
        }

        public async Task<Child> AddChildAsync(string streetName, int houseNumber, Child child) {
            Family family = file.Families.FirstOrDefault(f => f.StreetName.Equals(streetName) && f.HouseNumber == houseNumber);
            if (family == null) throw new NullReferenceException("No such child found");
            int current = family.Children.Max(c => c.Id);
            child.Id = current + 1;
            family.Children.Add(child);
            file.SaveData();
            return child;
        }

        public async Task<Child> UpdateChildAsync(int childId, Child updatedChild) {
            Child child = await GetChildAsync(childId);
            child.Age = updatedChild.Age;
            child.Height = updatedChild.Height;
            child.Sex = updatedChild.Sex;
            child.Weight = updatedChild.Weight;
            child.EyeColor = updatedChild.EyeColor;
            child.FirstName = updatedChild.FirstName;
            child.HairColor = updatedChild.HairColor;
            child.LastName = updatedChild.LastName;
            child.Interests = updatedChild.Interests;
            child.Pets = child.Pets;
            file.SaveData();
            return child;
        }

        public async Task DeleteChildAsync(int childId) {
            Child child = await GetChildAsync(childId);
            file.People.Remove(child);
            file.SaveData();
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