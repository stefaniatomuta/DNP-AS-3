using System.Collections.Generic;
using System.Threading.Tasks;

namespace FamilyManagerWebAPI.Data {
    public interface IDAO : IFamilyDAO, IAdultDAO, IChildDAO, IPetDAO {
        Task<IList<string>> GetEyeColorsAsync();
        Task<IList<string>> GetHairColorsAsync();
    }
}