using System;
using System.Threading.Tasks;
using MelbourneModernApp.Core.Models;
using MelbourneModernApp.Core.ViewModels;
using Microsoft.AspNetCore.Components;

namespace MelbourneModernApps.BlazorWasm.Pages
{
    public partial class Presenters
    {
        public Presenters()
        {
        }
        [Inject]
        private PresentersViewModel VM { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await VM.ExecuteLoadItemsCommand();
        }

        public void AddPresenter()
        {
            NavigationManager.NavigateTo("/presenters/detail");
        }

        public void EditPresenter(Presenter presenter)
        {
            NavigationManager.NavigateTo($"/presenters/detail/{presenter.Id}");
        }

        public void OpenWebPage(string url)
        {
            //Open twitter in new tab
        }
    }
}
