using System.Collections.Generic;
using System.Threading.Tasks;

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
    }
}