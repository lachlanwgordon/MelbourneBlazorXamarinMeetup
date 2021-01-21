using System;

namespace MelbourneBlazorXamarin.Core.Models
{
    public class Presenter : BaseModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string TwitterHandle { get; set; }
        public string GithubUrl { get; set; }
        public string BlogUrl { get; set; }
        public string YoutubeUrl { get; set; }
    }
}