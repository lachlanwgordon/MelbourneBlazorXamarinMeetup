﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MelbourneBlazorXamarin.Core.Models;

namespace MelbourneBlazorXamarin.Core.Services
{
    public class PresentationDataStore : IDataStore<Presentation>
    {
        static readonly List<Presentation> items = new List<Presentation>();

        public PresentationDataStore()
        {
            SeedDataMethod();
        }

        private void SeedDataMethod()
        {
            if (items.Any())
                return;
            var newitems = new List<Presentation>()
            {
                new Presentation { Id = Guid.NewGuid().ToString(), Name = "Blazor for Xamarin forms Developers", Date = new DateTime(2020,04,15), PresenterId = "9cb75bed-d7db-4a58-a3a0-e6523668061d", RepoUrl = "https://github.com/lachlanwgordon/MelbourneBlazorXamarin", VideoUrl="https://www.youtube.com/embed/pz8lEAb_Qes" },
                new Presentation { Id = Guid.NewGuid().ToString(), Name = "App Center changed my life", Date = new DateTime(2020,04,15), PresenterId = "9cb75bed-d7db-4a58-a3a0-e6523668061d", RepoUrl = "https://github.com/lachlanwgordon/MelbourneBlazorXamarin", VideoUrl="https://www.youtube.com/embed/pz8lEAb_Qes" }
            };
            items.AddRange(newitems);
        }



        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Presentation arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Presentation> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Presentation>> GetItemsAsync(bool forceRefresh = false)
        {
            var sortedItems = items.OrderBy(x => x.Name);
            return await Task.FromResult(sortedItems);
        }

        public async Task<bool> SaveItemAsync(Presentation item)
        {
            var oldItem = items.Where((Presentation arg) => arg.Id == item.Id).FirstOrDefault();
            if(oldItem != null)
                items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }
    }
}
