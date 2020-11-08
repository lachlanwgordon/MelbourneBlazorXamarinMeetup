using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using MelbourneBlazorXamarin.Core.Services;
using Microsoft.AspNetCore.Components;

namespace MelbourneBlazorXamarin.BlazorWasm.Services
{
    public class NavigationService : INavigationService
    {
        public NavigationService(NavigationManager navigationManager)
        {
            NavigationManager = navigationManager;
        }

        public NavigationManager NavigationManager { get; }

        public Task NavigateToPageAsync(string url)
        {
            NavigationManager.NavigateTo($"/{url}");
            return Task.CompletedTask;
        }

        public Task NavigateToPageAsync(string url, string parameterKey, string parameterValue)
        {
            NavigationManager.NavigateTo($"/{url}/{parameterValue}");
            return Task.CompletedTask;
        }

        public Task NavigateToPageAsync(string url, Dictionary<string, string> parameters)
        {
            var uri = $"/{url}";
            foreach (var param in parameters)
            {
                uri += $"/{param.Value}";
            }
            Debug.WriteLine($"Navigate to {uri} ");
            NavigationManager.NavigateTo(uri);
            return Task.CompletedTask;
        }
    }
}