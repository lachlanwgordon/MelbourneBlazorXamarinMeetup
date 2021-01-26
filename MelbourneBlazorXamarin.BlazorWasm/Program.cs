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
using Microsoft.AspNetCore.Http;


namespace MelbourneBlazorXamarin.BlazorWasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");



            //builder.Services.AddBaseAddressHttpClient();
            builder.Services.AddSingleton(_ => new HttpClient() { BaseAddress = new Uri(Settings.BaseUrl)});
            //builder.Services.AddSingleton(_ => new HttpClient());

            builder.Services.AddSingleton<IDataStore<Presenter>, PresenterDataStoreAPI>();
            builder.Services.AddTransient<PresentersViewModel>();
            builder.Services.AddTransient<PresenterDetailViewModel>();
            builder.Services.AddTransient<INavigationService, NavigationService>();
            var host = builder.Build();
            Container.Current.Services = host.Services;
            //Console.WriteLine("Looking for base address");
            //var context = host.Services.GetRequiredService<IHttpContextAccessor>();
            //var manager = 
            //Console.WriteLine(context);
            //var url = context.HttpContext.Request.PathBase;
            //Console.WriteLine(url);
            //var client = host.Services.GetRequiredService<HttpClient>();
            //Console.WriteLine(client);
            //client.BaseAddress = new Uri(url);
            //Console.WriteLine(client.BaseAddress);
            await host.RunAsync();
        }
    }
}
