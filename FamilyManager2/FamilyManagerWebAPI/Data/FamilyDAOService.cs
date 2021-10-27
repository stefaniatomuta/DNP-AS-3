using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace FamilyManagerWebAPI.Data {
    public class FamilyDAOService : IFamilyDAO {

        private string FamilyFile = "Data/families.json";
        private IList<Family> Families;

        public FamilyDAOService() {
            if (!File.Exists(FamilyFile)) {
                Seed();
                WriteFamiliesToFile();
            }
            else {
                string content = File.ReadAllText(FamilyFile);
                Families = JsonSerializer.Deserialize<List<Family>>(content);
            }
        }


        public async Task<IList<Family>> GetFamiliesAsync() {
            List<Family> families = new List<Family>(Families);
            return families;
        }

        public async Task<Family> GetFamilyAsync(string streetName, int houseNumber) {
            throw new System.NotImplementedException();
        }

        public async Task<Family> AddFamilyAsync(Family family) {
            throw new System.NotImplementedException();
        }

        public async Task<Family> RemoveFamilyAsync(string streetName, int houseNumber) {
            throw new System.NotImplementedException();
        }

        public async Task<Family> UpdateFamilyAsync(Family family) {
            throw new System.NotImplementedException();
        }
        
        
        private void WriteFamiliesToFile() {
            string familiesAsJson = JsonSerializer.Serialize(Families, new JsonSerializerOptions() {
                WriteIndented = true
            });
            File.WriteAllText(FamilyFile, familiesAsJson);
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
    }
}