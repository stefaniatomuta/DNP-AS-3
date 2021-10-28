using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Models;

namespace FamilyManagerWebAPI.Data {
    public class FileContext {
        private const string filePath = "Data/families.json";
        public IList<Family> Families { get; }
        public IList<Person> People { get; }
        public IList<Pet> Pets { get; }

        public FileContext() {
            if (!File.Exists(filePath)) {
                Seed();
                SaveDataToFile();
            }
            else {
                string content = File.ReadAllText(filePath);
                Families = JsonSerializer.Deserialize<List<Family>>(content);
                People = new List<Person>();
                Pets = new List<Pet>();
                foreach (Family f in Families)
                {
                    foreach (Adult adult in f.Adults)
                        People.Add(adult);
                    foreach (Child child in f.Children)
                        People.Add(child);
                    foreach (Pet pet in f.Pets) 
                        Pets.Add(pet);
                }
            }
        }

        private void Seed() {
            
        }

        private void SaveDataToFile() {
            
        }
        
        
    }
}