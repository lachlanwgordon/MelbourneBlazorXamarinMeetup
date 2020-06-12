using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MelbourneModernApp.Core.Services;
using Xamarin.Forms;

namespace MelbourneModernApps.Forms.Services
{
    public class NavigationService : INavigationService
    {
        public async Task NavigateToPageAsync(string url)
        {
            await Shell.Current.GoToAsync($"/{url}");
        }

        public async Task NavigateToPageAsync(string url, string parameterKey, string parameterValue)
        {
            await Shell.Current.GoToAsync($"/{url}?{parameterKey}={parameterValue}");
        }
    }
}