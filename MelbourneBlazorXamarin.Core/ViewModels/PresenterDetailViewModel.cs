using System;
using System.Threading.Tasks;
using MelbourneBlazorXamarin.Core.Models;
using MelbourneBlazorXamarin.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MelbourneBlazorXamarin.Core.ViewModels
{
    public class PresenterDetailViewModel : BaseViewModel
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

        string twitterHandle;
        public string TwitterHandle
        {
            get => twitterHandle;
            set
            {
                SetProperty(ref twitterHandle, value);
            }
        }

        string githubUrl;
        public string GithubUrl
        {
            get => githubUrl;
            set
            {
                SetProperty(ref githubUrl, value);
            }
        }

        string blogUrl;
        public string BlogUrl
        {
            get => blogUrl;
            set
            {
                SetProperty(ref blogUrl, value);
            }
        }

        string youtubeUrl;
        public string YoutubeUrl
        {
            get => youtubeUrl;
            set
            {
                SetProperty(ref youtubeUrl, value);
            }
        }


        IDataStore<Presenter> DataStore;
        INavigationService NavigationService;

        public PresenterDetailViewModel(IDataStore<Presenter> dataStore, INavigationService navigationService)
        {
            DataStore = dataStore;
            NavigationService = navigationService;
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
            TwitterHandle = item.TwitterHandle;
            GithubUrl = item.GithubUrl;
            BlogUrl = item.BlogUrl;
            YoutubeUrl = item.YoutubeUrl;
        }

        public async Task Save()
        {
            var valid = true;
            if (string.IsNullOrWhiteSpace(Name))
            {
                ValidationMessage = "Please enter a name";
                valid = false;
                return;
            }
            if (string.IsNullOrWhiteSpace(Description))
            {
                ValidationMessage = "Please enter a description";
                valid = false;
                return;
            }
            if (string.IsNullOrWhiteSpace(ImageUrl))
            {
                ValidationMessage = "Please enter an image url";
                valid = false;
                return;
            }
            bool success = false;

            if (valid)
            {
                if (Item == null)
                {
                    Item = new Presenter();
                }
                
                Item.Name = Name;
                Item.Description = Description;
                Item.ImageUrl = ImageUrl;
                Item.TwitterHandle = TwitterHandle;
                Item.GithubUrl = GithubUrl;
                Item.BlogUrl = BlogUrl;
                Item.YoutubeUrl = YoutubeUrl;

                success = await DataStore.SaveItemAsync(Item);
                if (!success)
                    ValidationMessage = "Failed to save item";
            }

            

            if (valid && success)
                await NavigationService.NavigateToPageAsync("presenters");

        }
    }
}
