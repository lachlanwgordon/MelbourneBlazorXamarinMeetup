using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MelbourneBlazorXamarin.Views;
using MelbourneBlazorXamarin.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using MelbourneBlazorXamarin.Core.Models;
using MelbourneBlazorXamarin.Core.ViewModels;
using MelbourneBlazorXamarin.Forms.Services;

namespace MelbourneBlazorXamarin.Forms
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            var services = new ServiceCollection();

            services.AddSingleton<IDataStore<Presenter>, PresenterDataStore>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddTransient<PresentersViewModel>();
            services.AddTransient<PresenterDetailViewModel>();

            var serviceProvider = services.BuildServiceProvider(validateScopes: true);

            var scope = serviceProvider.CreateScope();

            Container.Current.Services = serviceProvider;

            MainPage = new AppShell();
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
