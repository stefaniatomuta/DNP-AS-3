using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Models;

namespace FamilyManagerWebAPI.Data {
    public class FileContext {
        private const string filePath = "Data/families.json";
        public IList<Family> Families { get; set; }
        public IList<Person> People { get; set; }
        public IList<Pet> Pets { get; set; }

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
                foreach (Family f in Families) {
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
            Family[] f = {
                new Family() {
                    Adults = {
                        new Adult() {
                            Age = 35,
                            EyeColor = "brown",
                            FirstName = "Adriana",
                            HairColor = "red",
                            Height = 175,
                            Id = 1,
                            JobTitle = new Job() {
                                JobTitle = "Bartender",
                                Salary = 12000
                            },
                            LastName = "Grecea",
                            Sex = "F",
                            Weight = 70
                        }
                    },
                    Children = {
                        new Child() {
                            Age = 12,
                            EyeColor = "blue",
                            FirstName = "Morten",
                            HairColor = "Green",
                            Height = 180,
                            Weight = 175,
                            Id = 2,
                            Interests = {
                                new Interest() {
                                    Type = "Jogging",
                                    Description = "Running in the morning"
                                }
                            },
                            LastName = "Hansen",
                            Sex = "M"
                        }
                    },
                    HouseNumber = 23,
                    StreetName = "Sundvej"
                }
            };
            Families = f.ToList();
        }

        public void SaveDataToFile() {
            string familiesAsJson = JsonSerializer.Serialize(Families, new JsonSerializerOptions() {
                WriteIndented = true
            });
            File.WriteAllText(filePath, familiesAsJson);
        }
    }
}
