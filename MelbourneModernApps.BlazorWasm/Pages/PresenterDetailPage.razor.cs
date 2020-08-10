using System;
using System.Threading.Tasks;
using MelbourneModernApp.Core.ViewModels;
using Microsoft.AspNetCore.Components;

namespace MelbourneModernApps.BlazorWasm.Pages
{
    public partial class PresenterDetailPage
    {
        [Inject] private PresenterDetailViewModel VM { get; set; }

        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await VM.LoadPresenter(Id);
        }
    }
}