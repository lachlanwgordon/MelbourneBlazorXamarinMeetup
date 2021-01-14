using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MelbourneBlazorXamarin.Core.Services;
using MelbourneBlazorXamarin.Core.Models;
using MelbourneBlazorXamarin.Core.ViewModels;
using MelbourneBlazorXamarin.BlazorWasm.Services;
using System.Net.Http;

namespace MelbourneBlazorXamarin.BlazorWasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");



            //builder.Services.AddBaseAddressHttpClient();
            builder.Services.AddSingleton(_ => new HttpClient());

            builder.Services.AddSingleton<IDataStore<Presenter>, PresenterDataStoreAPI>();
            builder.Services.AddTransient<PresentersViewModel>();
            builder.Services.AddTransient<PresenterDetailViewModel>();
            builder.Services.AddTransient<INavigationService, NavigationService>();

            var host = builder.Build();
            Container.Current.Services = host.Services;

            await host.RunAsync();
        }
    }
}
