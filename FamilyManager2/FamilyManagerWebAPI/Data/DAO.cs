using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FamilyManagerWebAPI.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models;

namespace FamilyManagerWebAPI.Data {
    public class DAO : IDAO {
        public async Task<IList<string>> GetEyeColorsAsync() {
            IList<Person> people = await GetPeopleAsync();
            return people.Select(p => p.EyeColor).Distinct().ToList();
        }

        public async Task<IList<string>> GetHairColorsAsync() {
            IList<Person> people = await GetPeopleAsync();
            return people.Select(p => p.HairColor).Distinct().ToList();
        }

        public async Task<IList<Family>> GetFamiliesAsync() {
            using FamilyContext familyContext = new FamilyContext();
            return await familyContext.Families.Include(fam => fam.Adults).ThenInclude(a => a.Job).
                Include(fam =>fam.Children).ThenInclude(c => c.Interests ).Include(fam =>fam.Children).
                ThenInclude(c => c.Pets ).Include(fam => fam.Pets).ToListAsync();
        }

        public async Task<Family> GetFamilyAsync(string streetName, int houseNumber) {
            using FamilyContext familyContext = new FamilyContext();
            IList<Family> families = await GetFamiliesAsync();
            Family fam = families.FirstOrDefault(f =>
                    f.StreetName.Equals(streetName) && f.HouseNumber == houseNumber);
            if (fam == null) {
                throw new NullReferenceException("No family was found with these street name and house number");
            }

            return fam;
        }

        public async Task<Family> AddFamilyAsync(Family family) {
            Family fam = await GetFamilyAsync(family.StreetName, family.HouseNumber);
            if (fam != null) {
                throw new InvalidDataException("This family already exists");
            }

            using FamilyContext familyContext = new FamilyContext();
            EntityEntry<Family> created = await familyContext.Families.AddAsync(family);
            await familyContext.SaveChangesAsync();
            return created.Entity;
        }

        public async Task<Family> RemoveFamilyAsync(string streetName, int houseNumber) {
            Family fam = await GetFamilyAsync(streetName, houseNumber);
            using FamilyContext familyContext = new FamilyContext();
            familyContext.Families.Remove(fam);
            await familyContext.SaveChangesAsync();
            return fam;
        }

        public async Task<Family> UpdateFamilyAsync(string streetName, int houseNumber, Family family) {
            Family existing = await GetFamilyAsync(streetName, houseNumber);
            Family toUpdate = await GetFamilyAsync(family.StreetName, family.HouseNumber);
            if (existing != null) {
                throw new InvalidDataException("The place is already taken by another family");
            }

            toUpdate.StreetName = family.StreetName;
            toUpdate.HouseNumber = family.HouseNumber;
            toUpdate.Pets = family.Pets;
            toUpdate.Children = family.Children;
            toUpdate.Adults = family.Adults;
            using FamilyContext familyContext = new FamilyContext();
            familyContext.Update(toUpdate);
            await familyContext.SaveChangesAsync();
            return toUpdate;
        }

        public async Task<Adult> AddAdultAsync(string streetName, int houseNumber, Adult adult) {
            Family fam = await GetFamilyAsync(streetName, houseNumber);
            using FamilyContext familyContext = new FamilyContext();
            if (fam.Adults.Count < 2) {
                adult.Id = 0;
                Job job = familyContext.Families
                    .SelectMany(f => f.Adults)
                    .Select(a => a.Job)
                    .Where(j => j.JobTitle.Equals(adult.Job.JobTitle) && j.Salary == adult.Job.Salary)
                    .ToList()
                    .FirstOrDefault();
                
                if (job != null) {
                    adult.Job = job;
                    Console.WriteLine(job.JobTitle + " - " + job.Salary);
                }
                
                fam.Adults.Add(adult);
                await familyContext.AddAsync(adult);
                familyContext.Update(fam);
                await familyContext.SaveChangesAsync();
                return adult;
            }
            
            throw new Exception("Max 2 adults per family");
        }

        public async Task<IList<Adult>> GetAdultsByFamilyAsync(string streetName, int houseNumber) {
            Family family = await GetFamilyAsync(streetName, houseNumber);
            return family.Adults;
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
            Adult adult = await GetAdultAsync(id);
            using FamilyContext familyContext = new FamilyContext();
            familyContext.Remove(adult);
            await familyContext.SaveChangesAsync();
        }

        public async Task<Adult> UpdateAdultAsync(int id, Adult a) {
            using FamilyContext familyContext = new FamilyContext();
            Adult adult = await familyContext.Set<Adult>()
                .Where(a => a.Id == id)
                .Include(a => a.Job)
                .FirstOrDefaultAsync();
            adult.FirstName = a.FirstName;
            adult.LastName = a.LastName;
            adult.HairColor = a.HairColor;
            adult.Job = a.Job;
            adult.Age = a.Age;
            adult.Height = a.Height;
            adult.Weight = a.Weight;
            adult.EyeColor = a.EyeColor;
            
            familyContext.Set<Adult>().Update(adult);
            await familyContext.SaveChangesAsync();
            return adult;
        }

        public async Task<IList<Adult>> GetAdultsAsync() {
            using FamilyContext familyContext = new FamilyContext();
            return await familyContext.Families.SelectMany(fam => fam.Adults)
                .Include(adult => adult.Job)
                .ToListAsync();
        }

        public async Task<IList<Person>> GetPeopleAsync() {
            IList<Adult> adults = await GetAdultsAsync();
            IList<Child> children = await GetChildrenAsync();
            IList<Person> people = new List<Person>();
            foreach (Adult adult in adults) {
                people.Add(adult);
            }
            foreach (Child child in children) {
                people.Add(child);
            }
            return people;
        }

        public async Task<Person> GetPersonAsync(int id, string firstName, string lastName) {
            Person person = (await GetPeopleAsync()).FirstOrDefault(p =>
                p.Id == id && p.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                p.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
            if (person == null)
                throw new NullReferenceException("No such person found");
            return person;
        }

        public async Task<IList<Child>> GetChildrenAsync() {
            await using FamilyContext familyContext = new FamilyContext();
            return await familyContext.Families.SelectMany(f => f.Children).Include(child => child.Interests)
                .Include(child => child.Pets).ToListAsync();
        }

        public async Task<IList<Child>> GetChildrenAsync(string streetName, int houseNumber) {
            await using FamilyContext familyContext = new FamilyContext();
            Family family =
                familyContext.Families.FirstOrDefault(f =>
                    f.StreetName.Equals(streetName) && f.HouseNumber == houseNumber);
            if (family == null) throw new NullReferenceException("No such family found");
            return family.Children;
        }

        public async Task<Child> GetChildAsync(int childId) {
            await using FamilyContext familyContext = new FamilyContext();
            Child child = familyContext.Families.SelectMany(f => f.Children)
                .Include(c => c.Interests)
                .Include(c => c.Pets)
                .FirstOrDefault(c => c.Id == childId);
            if (child == null) throw new NullReferenceException("No such child found");
            return child;
        }

        public async Task<Child> AddChildAsync(string streetName, int houseNumber, Child child) {
            await using FamilyContext familyContext = new FamilyContext();
            Family family = await GetFamilyAsync(streetName, houseNumber);
            child.Id = 0;
            family.Children.Add(child);
            familyContext.Update(family);
            await familyContext.SaveChangesAsync();
            return child;
        }

        public async Task<Child> UpdateChildAsync(int childId, Child child) {
            await using FamilyContext familyContext = new FamilyContext();
            Child updated = await familyContext.Set<Child>()
                .Where(c => c.Id == childId)
                .Include(c => c.Interests)
                .Include(c => c.Pets)
                .FirstOrDefaultAsync();
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
            familyContext.Set<Child>().Update(updated);
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
            return (await GetFamiliesAsync()).SelectMany(f=>f.Pets).FirstOrDefault(p => p.Id == petId);
        }

        public async Task<IList<Pet>> GetPetsAsync(string street, int number) {
            await using FamilyContext familyContext = new FamilyContext();
            return (await GetFamilyAsync(street,number)).Pets;
        }

        public async Task<Pet> AddPetAsync(Pet pet, string street, int number) {
            await using FamilyContext familyContext = new FamilyContext();
            pet.Id = 0;
            Family fam = await GetFamilyAsync(street, number);
            fam.Pets.Add(pet);
            familyContext.Update(fam);
            await familyContext.SaveChangesAsync();
            return pet;
        }

        public async Task<Pet> AddPetAsync(Pet pet, string street, int number, int childId) {
            Family family = await GetFamilyAsync(street, number);
            Child child = family.Children.FirstOrDefault(c => c.Id == childId);
            await using FamilyContext familyContext = new FamilyContext();
            pet.Id = 0;
            child.Pets.Add(pet);
            familyContext.Update(family);
            await familyContext.SaveChangesAsync();
            return pet;
        }

        public async Task<Pet> UpdatePetAsync(int id, Pet pet) {
            await using FamilyContext familyContext = new FamilyContext();
            Pet p = await familyContext.Set<Pet>()
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            p.Age = pet.Age;
            p.Name = pet.Name;
            p.Species = pet.Species;
            familyContext.Set<Pet>().Update(p);
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