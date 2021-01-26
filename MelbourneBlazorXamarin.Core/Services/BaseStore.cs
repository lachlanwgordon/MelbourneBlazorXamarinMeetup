using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MelbourneBlazorXamarin.Core.Models;

namespace MelbourneBlazorXamarin.Core.Services
{
    public class BaseStore<T> : IDataStore<T> where T : BaseModel 
    {
        private readonly HttpClient httpClient;

        public BaseStore(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            try
            {
                var url = $"/api/{nameof(T)}";
                var items = await httpClient.GetFromJsonAsync<List<T>>(url);
                return items;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new List<T>();
            }
        }

        public Task<bool> SaveItemAsync(T item)
        {
            throw new NotImplementedException();
        }
    }
}
