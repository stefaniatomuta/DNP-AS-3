using System.Collections.Generic;
using System.Threading.Tasks;

namespace FamilyManager2UI.WebClient {
    public interface IRestClient {
        public Task<List<T>> GetAsync<T>();
        public Task<T> GetAsync<T>(int id);
        public Task<T> GetAsync<T>(string streetName, int streetNumber);
        public Task<T> GetAsync<T>(string username, string password);
        public Task<T> PostAsync<T>(T user);
        public Task<T> PostAsync<T>(T item, string streetName, int streetNumber);
        public Task<T> PostAsync<T>(T item, string streetName, int streetNumber, int childId);
        public Task<T> PutAsync<T>(T item, int id);
        public Task<object> DeleteAsync<T>(int id);
        public Task<object> DeleteAsync<T>(string streetName, int streetNumber);
        
    }
}