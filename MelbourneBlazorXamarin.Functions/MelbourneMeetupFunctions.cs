using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MelbourneBlazorXamarin.Core.Services;
using Microsoft.Azure.Cosmos.Table;
using MelbourneBlazorXamarin.Functions.Entities;
using System.Linq;

namespace MelbourneModenApps.Functions
{
    public static class MelbourneMeetupFunctions
    {
        [FunctionName(nameof(Presenter))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var storageConnectionString = Environment.GetEnvironmentVariable("StorageConnectionString");

            if (storageConnectionString == null)
                return new OkObjectResult("no connection string found");

            CloudStorageAccount storageAccount = CreateStorageAccountFromConnectionString(storageConnectionString);

            var client = storageAccount.CreateCloudTableClient(new TableClientConfiguration());


            string id = req.Query["id"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            var dummyStore = new PresenterDataStore();

            var table = client.GetTableReference("Presenter");
            await table.CreateIfNotExistsAsync();

            if (req.Method == HttpMethods.Get)
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    TableQuery<Presenter> rangeQuery = new TableQuery<Presenter>();
                    //.Where(
                    //TableQuery.CombineFilters(
                    //    TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Presenter"),
                    //    TableOperators.And,
                    //    TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.GreaterThan, "t")));

                    // Execute the query and loop through the results

                    var items = table.ExecuteQuery(rangeQuery);

                    if(items.Count() == 0)
                    {
                        var dummyItems = await dummyStore.GetItemsAsync();

                        foreach(var item in dummyItems)
                        {
                            var entity = Presenter.FromModel(item);

                            var insert = TableOperation.Insert(entity);
                            table.Execute(insert);
                        }
                        
                    }
                    items = table.ExecuteQuery(rangeQuery).ToList();

                    foreach (var entity in
                        await table.ExecuteQuerySegmentedAsync(rangeQuery, null))
                    {
                        log.LogInformation(
                            $"{entity.PartitionKey}\t{entity.RowKey}\t{entity.Timestamp}\t{entity.Name}");
                    }
                    return new OkObjectResult(items);
                }
                else
                {
                    var item = await dummyStore.GetItemAsync(id);
                    return new OkObjectResult(item);
                }
            }
            else
            {
                var presenter = JsonConvert.DeserializeObject<MelbourneBlazorXamarin.Core.Models.Presenter>(requestBody);
                var updated = dummyStore.UpdateItemAsync(presenter);
                return new OkObjectResult(presenter);
            }

        }


        public static CloudStorageAccount CreateStorageAccountFromConnectionString(string storageConnectionString)
        {
            CloudStorageAccount storageAccount;
            try
            {
                storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the application.");
                throw;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the sample.");
                Console.ReadLine();
                throw;
            }

            return storageAccount;
        }
    }

}
