using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FamilyManagerWebAPI.Persistance;
using Microsoft.EntityFrameworkCore;
using Models;

namespace FamilyManagerWebAPI.Data {
    public class DAO : IDAO {
        

        public async Task<IList<string>> GetEyeColorsAsync() {
            return file.People.Select(p => p.EyeColor).Distinct().ToList();
        }

        public async Task<IList<string>> GetHairColorsAsync() {
            return file.People.Select(p => p.HairColor).Distinct().ToList();
        }

        public async Task<IList<Family>> GetFamiliesAsync() {
            using FamilyContext familyContext = new FamilyContext();
            return  await familyContext.Families.ToListAsync();
        }

        public async Task<Family> GetFamilyAsync(string streetName, int houseNumber) {
            Family fam = file.Families.FirstOrDefault(f => f.StreetName.Equals(streetName) && f.HouseNumber == houseNumber);
            if (fam == null) {
                throw new NullReferenceException("No family was found with these street name and house number");
            }
            return fam;
        }

        public async Task<Family> AddFamilyAsync(Family family) {
            Family fam = file.Families.FirstOrDefault(f =>
                f.StreetName.Equals(family.StreetName) && f.HouseNumber == family.HouseNumber);
            if (fam != null) {
                throw new InvalidDataException("This family already exists");
            }
            file.Families.Add(family);
            file.SaveDataToFile();
            return family;
        }

        public async Task<Family> RemoveFamilyAsync(string streetName, int houseNumber) {
            Family fam = await GetFamilyAsync(streetName, houseNumber);
            file.Families.Remove(fam);
            file.SaveDataToFile();
            return fam;
        }

        public async Task<Family> UpdateFamilyAsync(string streetName, int houseNumber, Family family) {
            Family fam = await GetFamilyAsync(streetName, houseNumber);
            Family fami = await GetFamilyAsync(family.StreetName, family.HouseNumber);
            if (fami != null) {
                throw new InvalidDataException("The place is already taken by another family");
            }
            fam.StreetName = family.StreetName;
            fam.HouseNumber = family.HouseNumber;
            fam.Pets = family.Pets;
            fam.Children = family.Children;
            fam.Adults = family.Adults;
            file.SaveDataToFile();
            return fam;
        }

        public async Task<Adult> AddAdultAsync(string streetName, int houseNumber, Adult adult) {
            foreach (Family fam in file.Families) {
                if (fam.StreetName.Equals(streetName) && fam.HouseNumber == houseNumber) {
                    int current;
                    IList<Adult> adults = await GetAdultsAsync();
                    if (adults.Count == 0) 
                        current = 0;
                    else
                        current = (adults.Max(a => a.Id));
                    adult.Id = current + 1;
                    fam.Adults.Add(adult);
                }
            }
            file.SaveDataToFile();
            return adult;
        }
        public async Task<IList<Adult>> GetAdultsByFamilyAsync(string streetName, int houseNumber) {
            return file.Families.First(f => f.StreetName.Equals(streetName) && f.HouseNumber == houseNumber).Adults;
        }
        
        public async Task<Adult> GetAdultAsync(int id) {
            IList<Adult> adults = await GetAdultsAsync();
            Adult adult = adults.FirstOrDefault(adult => adult.Id == id);
            if (adult == null) {
                throw new NullReferenceException("There is no adult with such id");
            }
            return adult;
        }

        public async Task DeleteAdultAsync(int id) {
            foreach (var family in file.Families) {
                foreach (var adult in family.Adults) {
                    if (adult.Id == id) 
                        family.Adults.Remove(adult);
                    else {
                        throw new NullReferenceException("Cannot delete an adult that does not exist with that id");
                    }
                }
            }
            file.SaveDataToFile();
        }

        public async Task<Adult> UpdateAdultAsync(int id, Adult a) {
            Adult adult = await GetAdultAsync(id);
            adult.FirstName = a.FirstName;
            adult.LastName = a.LastName;
            adult.HairColor = a.HairColor;
            adult.Job = a.Job;
            adult.Age = a.Age;
            adult.Height = a.Height;
            adult.Weight = a.Weight;
            adult.EyeColor = a.EyeColor;
            file.SaveDataToFile();
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
        
        public async Task<IList<Person>> GetPeopleAsync() {
            IList<Person> people = new List<Person>();
            foreach (Family family in file.Families) {
                foreach (Adult adult in family.Adults) {
                    people.Add(adult);
                }

                foreach (Child child in family.Children) {
                    people.Add(child);
                }
            }
            return people;
        }

        public async Task<Person> GetPersonAsync(int id, string firstName, string lastName) {
            Person person = (await GetPeopleAsync()).FirstOrDefault
                (p => p.Id == id 
                && p.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) 
                && p.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
            if (person == null)
                throw new NullReferenceException("No such person found");
            return person;
        }

        public async Task<IList<Child>> GetChildrenAsync() {
            await using FamilyContext familyContext = new FamilyContext();
            return await familyContext.Families.SelectMany(f => f.Children)
                .Include(c=>c.Interests)
                .Include(c=>c.Pets)
                .ToListAsync();
        }

        public async Task<IList<Child>> GetChildrenAsync(string streetName, int houseNumber) {
            return (await GetFamilyAsync(streetName,houseNumber)).Children;
        }

        public async Task<Child> GetChildAsync(int childId) {
            Child child = (await GetChildrenAsync()).FirstOrDefault(c => c.Id == childId);
            if (child == null) throw new NullReferenceException("No such child found");
            return child;
        }

        public async Task<Child> AddChildAsync(string streetName, int houseNumber, Child child) {
            await using FamilyContext familyContext = new FamilyContext();
            child.Id = 0;
            (await GetChildrenAsync(streetName, houseNumber)).Add(child);
            await familyContext.SaveChangesAsync();
            return child;
        }

        public async Task<Child> UpdateChildAsync(int childId, Child child) {
            await using FamilyContext familyContext = new FamilyContext();
            Child updated = await GetChildAsync(childId);
            updated.Age = child.Age;
            updated.Height = child.Height;
            updated.Sex = child.Sex;
            updated.Weight = child.Weight;
            updated.EyeColor = child.EyeColor;
            updated.FirstName = child.FirstName;
            updated.HairColor = child.HairColor;
            updated.LastName = child.LastName;
            updated.Interests = child.Interests;
            updated.Pets = child.Pets;
            await familyContext.SaveChangesAsync();
            return updated;
        }

        public async Task DeleteChildAsync(int childId) {
            await using FamilyContext familyContext = new FamilyContext();
            Child child = await GetChildAsync(childId);
            familyContext.Remove(child);
            await familyContext.SaveChangesAsync();
        }

        public async Task<Pet> GetPetAsync(int petId) {
            await using FamilyContext familyContext = new FamilyContext();
            return familyContext.Families.SelectMany(f => f.Pets).FirstOrDefault(p => petId == p.Id);
        }

        public async Task<IList<Pet>> GetPetsAsync(string street, int number) {
            return (await GetFamilyAsync(street, number)).Pets;
        }

        public async Task<Pet> AddPetAsync(Pet pet, string street, int number) {
            await using FamilyContext familyContext = new FamilyContext();
            pet.Id = 0;
            (await GetFamilyAsync(street, number)).Pets.Add(pet);
            await familyContext.SaveChangesAsync();
            return pet;
        }

        public async Task<Pet> AddPetAsync(Pet pet, string street, int number, int childId) {
            await using FamilyContext familyContext = new FamilyContext();
            pet.Id = 0;
            familyContext.Families.First(f => f.StreetName.Equals(street) && f.HouseNumber == number)
                .Children.First(c => c.Id == childId).Pets.Add(pet);
            await familyContext.SaveChangesAsync();
            return pet;
        }

        public async Task<Pet> UpdatePetAsync(int id, Pet pet) {
            await using FamilyContext familyContext = new FamilyContext();
            Pet p = await GetPetAsync(id);
            p.Age = pet.Age;
            p.Name = pet.Name;
            p.Species = pet.Species;
            await familyContext.SaveChangesAsync();
            return p;
        }

        public async Task RemovePetAsync(int petId) {
            await using FamilyContext familyContext = new FamilyContext();
            familyContext.Remove(await GetPetAsync(petId));
            await familyContext.SaveChangesAsync();
        }
        
    }
}