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

        string validationMessage;
        public string ValidationMessage
        {
            get => validationMessage;
            set
            {
                SetProperty(ref validationMessage, value);
            }
        }

        public ItemDetailViewModel(Item item)
        {
            Title = item.Name;
            Item = item;
            Name = item.Name;
            Description = item.Description;
            ImageUrl = item.ImageUrl;
        }

        public ItemDetailViewModel()
        {
           Title = "New Presenter";
        }

        public async Task<bool> Save()
        {
            var valid = true;
            if(string.IsNullOrWhiteSpace(Name))
            {
                ValidationMessage = "Please enter a name";
                valid = false;
                return valid;
            }
            if (string.IsNullOrWhiteSpace(Description))
            {
                ValidationMessage = "Please enter a description";
                valid = false;
                return valid;
            }
            if (string.IsNullOrWhiteSpace(ImageUrl))
            {
                ValidationMessage = "Please enter an image url";
                valid = false;
                return valid;
            }
            bool success = false;

            if (valid)
            {
                if(Item == null)
                {
                    Item = new Item
                    {
                        Name = Name,
                        Description = Description,
                        ImageUrl = ImageUrl
                    };
                    success = await DataStore.AddItemAsync(Item);
                    if (!success)
                        ValidationMessage = "Failed to add new item";
                }
                else
                {
                    Item.Name = Name;
                    Item.Description = Description;
                    Item.ImageUrl = ImageUrl;
                    success = await DataStore.UpdateItemAsync(Item);
                    if (!success)
                        ValidationMessage = "Failed to update item";
                }
            }

            return valid && success;
        }
    }
}
