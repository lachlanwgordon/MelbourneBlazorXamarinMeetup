using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MelbourneModernApps.Views;
using MelbourneModernApp.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using MelbourneModernApp.Core.Models;
using MelbourneModernApp.Core.ViewModels;
using MelbourneModernApps.Forms.Services;

namespace MelbourneModernApps
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

            Device.SetFlags(new string[]
            {
                "Expander_Experimental",
                "AppThese_Experimental",
                "MediaElement_Experimental",
                "SwipeView_Experimental"
            });

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
