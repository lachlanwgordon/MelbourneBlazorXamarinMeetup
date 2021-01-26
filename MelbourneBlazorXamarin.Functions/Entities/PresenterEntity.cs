using System;
using MelbourneBlazorXamarin.Core.Models;
using Microsoft.Azure.Cosmos.Table;

namespace MelbourneBlazorXamarin.Functions.Entities
{
    public class Presenter : TableEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string TwitterHandle { get; set; }
        public string GithubUrl { get; set; }
        public string BlogUrl { get; set; }
        public string YoutubeUrl { get; set; }

        public static Presenter FromModel(Core.Models.Presenter model)
        {
            if (model.Id == null)
                model.Id = Guid.NewGuid().ToString();

            var entity = new Presenter
            {
                BlogUrl = model.BlogUrl,
                Description = model.Description,
                GithubUrl = model.GithubUrl,
                Id = model.Id,
                RowKey = model.Id,
                ImageUrl = model.ImageUrl,
                Name = model.Name,
                PartitionKey = nameof(Presenter),
                TwitterHandle = model.TwitterHandle,
                YoutubeUrl = model.YoutubeUrl
            };
            
            return entity;
        }
    }

}
