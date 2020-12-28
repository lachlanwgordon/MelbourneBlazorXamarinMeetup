using System;
using System.Threading.Tasks;
using MelbourneBlazorXamarin.Core.Services;
using Microsoft.MobileBlazorBindings;

namespace MelbourneBlazorXamarin.Forms.Services
{
    public class MBBNavigationService : INavigationService
    {
        private ShellNavigationManager navigationManager;

        public MBBNavigationService(ShellNavigationManager navigationManager)
        {
            this.navigationManager = navigationManager;
        }

        public async Task NavigateToPageAsync(string url)
        {
            await navigationManager.NavigateToAsync(url);
        }

        public async Task NavigateToPageAsync(string url, string parameterKey, string parameterValue)
        {
            await navigationManager.NavigateToAsync($"{url}/{parameterValue}");
        }
    }
}