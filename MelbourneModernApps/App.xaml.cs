using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MelbourneModernApps.Views;
using MelbourneModernApp.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using MelbourneModernApp.Core.Models;

namespace MelbourneModernApps
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            var services = new ServiceCollection();

            services.AddSingleton<IDataStore<Presenter>, MockDataStore>();

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
