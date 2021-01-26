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
        //readonly IHttpContextAccessor httpContextAccessor;



        public PresenterDataStoreAPI(HttpClient httpClient)//, IHttpContextAccessor httpContextAccessor)
        {
            this.httpClient = httpClient;
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Presenter> GetItemAsync(string id)
        {
            var url = $"/api/{nameof(Presenter)}?id={id}";
            var item = await httpClient.GetFromJsonAsync<Presenter>(url);
            return item;
        }

        public async Task<IEnumerable<Presenter>> GetItemsAsync(bool forceRefresh = false)
        {
            try
            {
#if DEBUG
                //When debugging locally the API function takes a while to startup
                await Task.Delay(2000);
#endif
                var url = $"/api/{nameof(Presenter)}";
                var items = await httpClient.GetFromJsonAsync<List<Presenter>>(url);
                return items;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new List<Presenter>();
            }
        }

        public async Task<bool> SaveItemAsync(Presenter item)
        {
            var url = $"/api/{nameof(Presenter)}";
            var success = await httpClient.PutAsJsonAsync<Presenter>(url, item);
            return success.IsSuccessStatusCode;
        }
    }
}
