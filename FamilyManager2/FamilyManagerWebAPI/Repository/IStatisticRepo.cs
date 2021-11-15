using System.Collections.Generic;
using System.Threading.Tasks;

namespace FamilyManagerWebAPI.Repository {
    public interface IStatisticRepo {
        Task<IList<string>> GetEyeColorsAsync();
        Task<IList<string>> GetHairColorsAsync();
    }
}