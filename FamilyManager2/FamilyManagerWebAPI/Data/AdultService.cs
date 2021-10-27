using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace FamilyManagerWebAPI.Data {
    public class AdultService : IAdultDAO {
        
        private string adultsFile = "families.json";
        private IList<Adult> adults;

        public AdultService() {
            if (!File.Exists(adultsFile)) {
                //Seed();
                WriteTodosToFile();
            }
            else {
                string content = File.ReadAllText(adultsFile);
                adults = JsonSerializer.Deserialize<List<Adult>>(content);
            }
        }
        
        private void WriteTodosToFile() {
            string adultsAsJson = JsonSerializer.Serialize(adults);
            File.WriteAllText(adultsFile, adultsAsJson);
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
        
    }
}