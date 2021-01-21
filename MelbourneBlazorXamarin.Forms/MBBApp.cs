using System;
using Xamarin.Forms;
using Microsoft.MobileBlazorBindings;
using Microsoft.Extensions.DependencyInjection;
using MelbourneBlazorXamarin.Core.ViewModels;
using MelbourneBlazorXamarin.Core.Services;
using MelbourneBlazorXamarin.Core.Models;
using MelbourneBlazorXamarin.Forms.Services;
using System.Net.Http;

namespace MelbourneBlazorXamarin.Forms
{
    public class MBBApp : Application
    {
        public MBBApp()
        {
            var host = MobileBlazorBindingsHost.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<ShellNavigationManager>();
                services.AddSingleton(_ => new HttpClient() { BaseAddress = new Uri(Settings.BaseUrl)});
                services.AddTransient<PresentersViewModel>();
                services.AddSingleton<IDataStore<Presenter>, PresenterDataStoreAPI>();
                services.AddSingleton<INavigationService, MBBNavigationService>();
            }).Build();

            MainPage = new ContentPage();
            //var shell = new MBBAppShell();
            host.AddComponent<MBBAppShell>(this);
        }
    }
}
