using System;
using Microsoft.MobileBlazorBindings;
using Microsoft.Extensions.Hosting;
using Xamarin.Essentials;
using Xamarin.Forms;
using MelbourneModernApps.MBB.Pages;
using Microsoft.Extensions.DependencyInjection;
using MelbourneModernApp.Core.ViewModels;
using MelbourneModernApp.Core.Services;
using MelbourneModernApp.Core.Models;
using MelbourneModernApps.MBB.Services;

namespace MelbourneModernApps.MBB
{
    public class App : Application
    {
        public static IHost Host;
        public App()
        {
            var host = MobileBlazorBindingsHost.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    // Register app-specific services
                    //services.AddSingleton<AppState>();
                    services.AddTransient<PresentersViewModel>();
                    services.AddTransient<PresenterDetailViewModel>();
                    services.AddSingleton<IDataStore<Presenter>, PresenterDataStore>();
                    services.AddSingleton<INavigationService, NavigationService>();
                    services.AddSingleton<ShellNavigationManager>();
                })
                .Build();

            MainPage = new ContentPage();
            Host = host;
            host.AddComponent<AppShell>(parent: this);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
