using System;
namespace MelbourneBlazorXamarin.Core.Models
{
    public class Presentation : BaseModel
    {
        public Presentation()
        {
        }

        public string PresenterId { get; set; }
        public string RepoUrl { get; set; }
        public string VideoUrl { get; set; }
        public DateTime Date { get; set; }
    }
}
