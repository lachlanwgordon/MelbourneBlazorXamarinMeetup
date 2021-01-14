using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MelbourneBlazorXamarin.Core.Models;
using MelbourneBlazorXamarin.Core.Services;

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

            string id = req.Query["id"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            

            var dummyStore = new PresenterDataStore();

            if(req.Method == HttpMethods.Get)
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    var items = await dummyStore.GetItemsAsync();
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
                var presenter = JsonConvert.DeserializeObject<Presenter>(requestBody);
                var updated = dummyStore.UpdateItemAsync(presenter);
                return new OkObjectResult(presenter);

            }

        }
    }
}
