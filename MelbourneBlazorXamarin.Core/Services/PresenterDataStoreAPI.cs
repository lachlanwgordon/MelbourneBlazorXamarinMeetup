using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MelbourneBlazorXamarin.Core.Models;
using System.Net.Http.Json;
using System.Diagnostics;

namespace MelbourneBlazorXamarin.Core.Services
{
    public class PresenterDataStoreAPI : IDataStore<Presenter>
    {
        readonly HttpClient httpClient;
        public PresenterDataStoreAPI(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<bool> AddItemAsync(Presenter item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Presenter> GetItemAsync(string id)
        {
            var baseUrl = "/api";
            var url = $"{baseUrl}/{nameof(Presenter)}?id={id}";
            var item = await httpClient.GetFromJsonAsync<Presenter>(url);
            return item;
        }

        public async Task<IEnumerable<Presenter>> GetItemsAsync(bool forceRefresh = false)
        {
            try
            {
                var baseUrl = "/api";
                Debug.WriteLine(baseUrl);
                Console.WriteLine(baseUrl);
                //var baseUrl = "http://localhost:7071/api";
                var url = $"{baseUrl}/{nameof(Presenter)}";
                Console.WriteLine(url);
                Console.WriteLine(httpClient.BaseAddress);
                var items = await httpClient.GetFromJsonAsync<List<Presenter>>(url);
                return items;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine(httpClient.BaseAddress);
                return new List<Presenter>();
            }
        }

        public Task<bool> UpdateItemAsync(Presenter item)
        {
            throw new NotImplementedException();
        }
    }
}
