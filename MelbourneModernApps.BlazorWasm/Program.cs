using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MelbourneModernApp.Core.Services;
using MelbourneModernApp.Core.Models;
using MelbourneModernApp.Core.ViewModels;
using MelbourneModernApps.BlazorWasm.Services;

namespace MelbourneModernApps.BlazorWasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddBaseAddressHttpClient();
            builder.Services.AddSingleton<IDataStore<Presenter>, PresenterDataStore>();
            builder.Services.AddTransient<PresentersViewModel>();
            builder.Services.AddTransient<PresenterDetailViewModel>();
            builder.Services.AddTransient<INavigationService, NavigationService>();

            var host = builder.Build();
            Container.Current.Services = host.Services;

            await host.RunAsync();
        }
    }
}
