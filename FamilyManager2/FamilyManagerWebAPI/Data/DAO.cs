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
        private FamilyContext familyContext;

        public DAO(FamilyContext familyContext) {
            this.familyContext = familyContext;
        }
        
        public async Task<IList<string>> GetEyeColorsAsync() {
            IList<Person> people = await GetPeopleAsync();
            return people.Select(p => p.EyeColor)
                .Distinct()
                .ToList();
        }

        public async Task<IList<string>> GetHairColorsAsync() {
            IList<Person> people = await GetPeopleAsync();
            return people.Select(p => p.HairColor)
                .Distinct()
                .ToList();
        }

        public async Task<IList<Family>> GetFamiliesAsync() {
            return await familyContext.Families
                .Include(fam => fam.Adults)
                    .ThenInclude(a => a.Job)
                .Include(fam => fam.Children)
                    .ThenInclude(c => c.Interests)
                .Include(fam => fam.Children)
                    .ThenInclude(c => c.Pets)
                .Include(fam => fam.Pets)
                .ToListAsync();
        }

        public async Task<Family> GetFamilyAsync(string streetName, int houseNumber) {
            Family family = (await GetFamiliesAsync())
                .FirstOrDefault(f => f.StreetName.Equals(streetName) && f.HouseNumber == houseNumber);
            return family;
        }

        public async Task<Family> AddFamilyAsync(Family family) {
            Family fam = await GetFamilyAsync(family.StreetName, family.HouseNumber);
            if (fam != null) throw new InvalidDataException("This family already exists");

            EntityEntry<Family> created = await familyContext.Families.AddAsync(family);
            await familyContext.SaveChangesAsync();
            return created.Entity;
        }

        public async Task<Family> RemoveFamilyAsync(string streetName, int houseNumber) {
            Family fam = await GetFamilyAsync(streetName, houseNumber);
            if (fam == null) throw new NullReferenceException("No family was found with this street name and house number");
            
            familyContext.Families.Remove(fam);
            await familyContext.SaveChangesAsync();
            return fam;
        }

        public async Task<Family> UpdateFamilyAsync(string streetName, int houseNumber, Family family) {
            Family existing = await GetFamilyAsync(streetName, houseNumber);
            if (existing != null) throw new InvalidDataException("The place is already taken by another family");
            
            Family toUpdate = await GetFamilyAsync(family.StreetName, family.HouseNumber);
            if (toUpdate == null) throw new NullReferenceException("No family was found with this street name and house number");
            
            toUpdate.StreetName = family.StreetName;
            toUpdate.HouseNumber = family.HouseNumber;
            toUpdate.Children = family.Children;
            toUpdate.Adults = family.Adults;
            toUpdate.Pets = family.Pets;
            
            familyContext.Update(toUpdate);
            await familyContext.SaveChangesAsync();
            return toUpdate;
        }

        public async Task<Adult> AddAdultAsync(string streetName, int houseNumber, Adult adult) {
            Family fam = await GetFamilyAsync(streetName, houseNumber);
            if (fam == null) throw new NullReferenceException("No family was found with this street name and house number");
            
            if (fam.Adults.Count < 2) {
                adult.Id = 0;
                Job job = await familyContext.Set<Job>()
                    .FirstOrDefaultAsync(j => j.JobTitle.Equals(adult.Job.JobTitle) && j.Salary == adult.Job.Salary);
                
                if (job != null) {
                    adult.Job = job;
                }
                
                // Add adult
                Adult added = (await familyContext.Set<Adult>().AddAsync(adult)).Entity;
                
                // Update family
                fam.Adults.Add(added);
                familyContext.Update(fam);
                await familyContext.SaveChangesAsync();
                return adult;
            }
            
            throw new InvalidDataException("Max 2 adults per family");
        }

        public async Task<IList<Adult>> GetAdultsByFamilyAsync(string streetName, int houseNumber) {
            Family family = await GetFamilyAsync(streetName, houseNumber);
            if (family == null) throw new NullReferenceException("No family was found with this street name and house number");

            return family.Adults;
        }

        public async Task<Adult> GetAdultAsync(int id) {
            Adult adult = await familyContext.Set<Adult>()
                .Include(a => a.Job)
                .FirstOrDefaultAsync(a => a.Id == id);

            return adult;
        }

        public async Task DeleteAdultAsync(int id) {
            Adult adult = await GetAdultAsync(id);
            if (adult == null) throw new NullReferenceException("There is no adult with such id");
            
            familyContext.Set<Adult>().Remove(adult);
            await familyContext.SaveChangesAsync();
        }

        public async Task<Adult> UpdateAdultAsync(int id, Adult a) {
            Adult adult = await GetAdultAsync(id);
            if (adult == null) throw new NullReferenceException("There is no adult with such id");

            Job job = await familyContext.Set<Job>()
                .FirstOrDefaultAsync(j => j.JobTitle.ToLower().Equals(a.Job.JobTitle.ToLower()) && j.Salary == a.Job.Salary);
            if (job != null) a.Job = job;
            
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
            return await familyContext.Set<Adult>()
                .Include(a => a.Job)
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
                p.Id == id && p.FirstName.ToLower().Equals(firstName.ToLower()) &&
                p.LastName.ToLower().Equals(lastName.ToLower()));
            
            return person;
        }

        public async Task<IList<Child>> GetChildrenAsync() {
            return await familyContext.Set<Child>()
                .Include(c => c.Interests)
                .Include(c => c.Pets)
                .ToListAsync();
        }

        public async Task<IList<Child>> GetChildrenAsync(string streetName, int houseNumber) {
            Family family = await GetFamilyAsync(streetName, houseNumber);
            if (family == null) throw new NullReferenceException("No family was found with this street name and house number");
            
            return family.Children;
        }

        public async Task<Child> GetChildAsync(int childId) {
            Child child = await familyContext.Set<Child>()
                .Include(c => c.Interests)
                .Include(c => c.Pets)
                .FirstOrDefaultAsync(c => c.Id == childId);
            
            return child;
        }

        public async Task<Child> AddChildAsync(string streetName, int houseNumber, Child child) {
            Family family = await GetFamilyAsync(streetName, houseNumber);
            if (family == null) throw new NullReferenceException("No family was found with this street name and house number");
            
            child.Id = 0;
            
            // Loop through interests, if any are already in the database, update the reference in the Child.Interests
            var interests = familyContext.Set<Interest>();
            for (int x = 0; x < child.Interests.Count; x++) {
                var ci = await interests.FirstOrDefaultAsync(i =>
                    i.Description.ToLower().Equals(child.Interests[x].Description.ToLower()) &&
                    i.Type.ToLower().Equals(child.Interests[x].Type.ToLower()));
                if (ci != null) child.Interests[x] = ci;
            }
            
            // Loop through interests, if any are already in the database, update the reference in the Child.Pets
            var pets = familyContext.Set<Pet>();
            for (int x = 0; x < child.Pets.Count; x++) {
                var cp = await pets.FirstOrDefaultAsync(p => p.Id == child.Pets[x].Id);
                if (cp != null) child.Pets[x] = cp;
            }
            
            // Add child
            Child added = (await familyContext.Set<Child>().AddAsync(child)).Entity;
            
            // Update family
            family.Children.Add(added);
            familyContext.Update(family);
            await familyContext.SaveChangesAsync();
            return added;
        }

        public async Task<Child> UpdateChildAsync(int childId, Child child) {
            Child updated = await GetChildAsync(childId);
            if (updated == null) throw new NullReferenceException("There is no child with such id");
            
            // Loop through interests, if any are already in the database, update the reference in the Child.Interests
            var interests = familyContext.Set<Interest>();
            for (int x = 0; x < child.Interests.Count; x++) {
                var ci = await interests.FirstOrDefaultAsync(i =>
                    i.Description.ToLower().Equals(child.Interests[x].Description.ToLower()) &&
                    i.Type.ToLower().Equals(child.Interests[x].Type.ToLower()));
                if (ci != null) child.Interests[x] = ci;
            }
            
            // Loop through interests, if any are already in the database, update the reference in the Child.Pets
            var pets = familyContext.Set<Pet>();
            for (int x = 0; x < child.Pets.Count; x++) {
                var cp = await pets.FirstOrDefaultAsync(p => p.Id == child.Pets[x].Id);
                if (cp != null) {
                    child.Pets[x] = cp;
                } else {
                    // Add the pet to the database, because for whatever reason, this is needed.
                    // It kinda doesn't make sense considering new interests work as well as new jobs for the adult...
                    // Might have to do with the non-composite PK perhaps? Anyway, very odd...
                    Pet added = (await familyContext.Set<Pet>().AddAsync(child.Pets[x])).Entity;
                    child.Pets[x] = added;
                }
            }
            
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
            Child child = await GetChildAsync(childId);
            if (child == null) throw new NullReferenceException("There is no child with such id");

            familyContext.Set<Child>().Remove(child);
            await familyContext.SaveChangesAsync();
        }
        

        public async Task<Pet> GetPetAsync(int petId) {
            Pet pet = await familyContext.Set<Pet>().FirstOrDefaultAsync(p => p.Id == petId);
            return pet;
        }

        public async Task<IList<Pet>> GetPetsAsync(string street, int number) {
            Family family = await GetFamilyAsync(street, number);
            if (family == null) throw new NullReferenceException("No family was found with this street name and house number");
            IEnumerable<Pet> childPets = family.Children.SelectMany(c => c.Pets);
            return family.Pets.Concat(childPets).ToList();
        }

        public async Task<Pet> AddPetAsync(Pet pet, string street, int number) {
            Family family = await GetFamilyAsync(street, number);
            if (family == null) throw new NullReferenceException("No family was found with this street name and house number");

            pet.Id = 0;
            
            // Add pet
            Pet added = (await familyContext.Set<Pet>().AddAsync(pet)).Entity;
            
            // Update family
            family.Pets.Add(added);
            familyContext.Update(family);
            await familyContext.SaveChangesAsync();
            return added;
        }

        public async Task<Pet> AddPetAsync(Pet pet, string street, int number, int childId) {
            Family family = await GetFamilyAsync(street, number);
            if (family == null) throw new NullReferenceException("No family was found with this street name and house number");

            Child child = family.Children.FirstOrDefault(c => c.Id == childId);
            if (child == null) throw new NullReferenceException("There is no child with such id");
            
            // Add pet
            Pet added = (await familyContext.Set<Pet>().AddAsync(pet)).Entity;
            
            // Update child
            child.Pets.Add(added);
            familyContext.Set<Child>().Update(child);
            await familyContext.SaveChangesAsync();
            return added;
        }

        public async Task<Pet> UpdatePetAsync(int id, Pet pet) {
            Pet toUpdate = await GetPetAsync(id);
            if (toUpdate == null) throw new NullReferenceException("There is no pet with such id");

            toUpdate.Age = pet.Age;
            toUpdate.Name = pet.Name;
            toUpdate.Species = pet.Species;
            familyContext.Set<Pet>().Update(toUpdate);
            await familyContext.SaveChangesAsync();
            return toUpdate;
        }

        public async Task RemovePetAsync(int petId) {
            Pet pet = await GetPetAsync(petId);
            if (pet == null) throw new NullReferenceException("There is no pet with such id");
            familyContext.Set<Pet>().Remove(pet);
            await familyContext.SaveChangesAsync();
        }
    }
}