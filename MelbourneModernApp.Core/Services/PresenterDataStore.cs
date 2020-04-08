using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MelbourneModernApp.Core.Models;

namespace MelbourneModernApp.Core.Services
{
    public class MockDataStore : IDataStore<Presenter>
    {
        static readonly List<Presenter> items = new List<Presenter>();

        public MockDataStore()
        {
            SeedData();
        }

        private void SeedData()
        {
            if (items.Any())
                return;
            var newitems = new List<Presenter>()
            {
                new Presenter { Id = Guid.NewGuid().ToString(), Name = "Kym Phillpots", Description="This is an item description.", ImageUrl="https://pbs.twimg.com/profile_images/866159039180189696/mZc3rn30_400x400.jpg", GithubUrl = "https://github.com/kphillpotts", YoutubeUrl ="https://www.youtube.com/user/kphillpotts", BlogUrl = "https://kymphillpotts.com/", TwitterHandle="@kphillpots" },
                new Presenter { Id = Guid.NewGuid().ToString(), Name = "Rod Hemphill", Description="This is an item description.", ImageUrl="https://pbs.twimg.com/profile_images/871482427557855232/DowYSDdP_400x400.jpg" },
                new Presenter { Id = Guid.NewGuid().ToString(), Name = "Lachlan Gordon", Description="This is an item description." },
                new Presenter { Id = Guid.NewGuid().ToString(), Name = "Michael Whitehead", Description="This is an item description." },
                new Presenter { Id = Guid.NewGuid().ToString(), Name = "Ryan Davis", Description="This is an item description." },
                new Presenter { Id = Guid.NewGuid().ToString(), Name = "Matthew Robbins", Description="This is an item description." }
            };
            items.AddRange(newitems);
        }

        public async Task<bool> AddItemAsync(Presenter item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Presenter item)
        {
            var oldItem = items.Where((Presenter arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Presenter arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Presenter> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Presenter>> GetItemsAsync(bool forceRefresh = false)
        {
            var sortedItems = items.OrderBy(x => x.Name);
            return await Task.FromResult(sortedItems);
        }
    }
}