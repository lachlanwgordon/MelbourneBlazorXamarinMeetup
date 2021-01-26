//using System;
//using Microsoft.Azure.Functions.Extensions.DependencyInjection;
//using Microsoft.Extensions.DependencyInjection;
//using System.IO;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Azure.WebJobs;
//using Microsoft.Azure.WebJobs.Extensions.Http;
//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Logging;
//using Newtonsoft.Json;
//using MelbourneBlazorXamarin.Core.Services;
//using MelbourneBlazorXamarin.Functions.Entities;
//using System.Linq;
//using Microsoft.Azure.Storage;

//[assembly: FunctionsStartup(typeof(MelbourneBlazorXamarin.Functions.Startup))]
//namespace MelbourneBlazorXamarin.Functions
//{

//    public class Startup : FunctionsStartup
//    {
        

//        public override void Configure(IFunctionsHostBuilder builder)
//        {


//            var storageConnectionString = Environment.GetEnvironmentVariable("StorageConnectionString");

//            CloudStorageAccount storageAccount = CreateStorageAccountFromConnectionString(storageConnectionString);

//            var client = storageAccount.CreateCloudTableClient(new TableClientConfiguration());

//            builder.Services.AddSingleton(_ => client);

//        }


//        public static CloudStorageAccount CreateStorageAccountFromConnectionString(string storageConnectionString)
//        {
//            CloudStorageAccount storageAccount;
//            try
//            {
//                storageAccount = CloudStorageAccount.Parse(storageConnectionString);
//            }
//            catch (FormatException)
//            {
//                Console.WriteLine("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the application.");
//                throw;
//            }
//            catch (ArgumentException)
//            {
//                Console.WriteLine("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the sample.");
//                Console.ReadLine();
//                throw;
//            }

//            return storageAccount;
//        }
//    }
//}
