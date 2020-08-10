using System;
using System.Threading.Tasks;
using MelbourneModernApp.Core.Services;
//using MelbourneModernApps.MBB.Components;
using MelbourneModernApps.MBB.Pages;
using Microsoft.MobileBlazorBindings;
using Xamarin.Forms;

namespace MelbourneModernApps.MBB.Services
{
    public class NavigationService : INavigationService
    {
        private ShellNavigationManager NavigationManager;

        public NavigationService(ShellNavigationManager navigationManager)
        {
            NavigationManager = navigationManager;
        }

        public Task NavigateToPageAsync(string url)
        {
            throw new NotImplementedException();
        }

        public async Task NavigateToPageAsync(string url, string parameterKey, string parameterValue)
        {
            url = $"{url}/{parameterValue}";
            //await Shell.Current.GoToAsync("presenters/detail");

            //var page = new ComponentPage();
            //App.Host.AddComponent<PresenterDetailPage>(parent: page);

            //NavView.Current.NavigationParameter = parameterValue;

            //aw÷ait Shell.Current.Navigation.PushAsync(page);
            //NavView.Current.OnNavigationTo(parameterValue);
            //NavigationView.Current.NavigationParameter = parameterValue;

            url = $"/presenterdetails/{parameterValue}";

            await NavigationManager.NavigateToAsync(url);
        }
    }
}