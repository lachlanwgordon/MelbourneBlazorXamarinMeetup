using System;
using System.Threading.Tasks;
using MelbourneModernApp.Core.Models;

namespace MelbourneModernApp.Core.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public ItemDetailViewModel(Item item = null)
        {
            if(item != null)
            {
                Title = item.Name;
                Item = item;
                Name = item.Name;
                Description = item.Description;
                ImageUrl = item.ImageUrl;
            }
            else
            {
                Title = "New Presenter";
            }
        }

        public async Task<bool> Save()
        {
            return true;
        }
    }
}
