using System;
namespace MelbourneModernApp.Core.Models
{
    public class Presentation
    {
        public Presentation()
        {
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string PresenterId { get; set; }
        public string RepoUrl { get; set; }
        public string VideoUrl { get; set; }
        public DateTime Date { get; set; }
        public Presenter Presenter { get; set; }

    }
}
