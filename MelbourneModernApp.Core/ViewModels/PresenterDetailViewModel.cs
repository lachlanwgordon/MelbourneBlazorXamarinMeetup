using System;
using System.Threading.Tasks;
using MelbourneModernApp.Core.Models;

namespace MelbourneModernApp.Core.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Presenter Item { get; set; }

        string name; 
        public string Name
        {
            get => name;
            set
            {
                SetProperty(ref name, value);
            }
        }
        string description;
        public string Description
        {
            get => description;
            set
            {
                SetProperty(ref description, value);
            }
        }

        string imageUrl;
        public string ImageUrl
        {
            get => imageUrl;
            set
            {
                SetProperty(ref imageUrl, value);
            }
        }

        string validationMessage;
        public string ValidationMessage
        {
            get => validationMessage;
            set
            {
                SetProperty(ref validationMessage, value);
            }
        }

        public ItemDetailViewModel()
        {
           Title = "New Presenter";
        }

        public async Task LoadPresenter(string id)
        {
            var presenter = await DataStore.GetItemAsync(id);
            Item = presenter;
            PopulateDetails(presenter);
        }

        public void PopulateDetails(Presenter item)
        {
            Title = item.Name;
            Item = item;
            Name = item.Name;
            Description = item.Description;
            ImageUrl = item.ImageUrl;
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
                    Item = new Presenter
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
