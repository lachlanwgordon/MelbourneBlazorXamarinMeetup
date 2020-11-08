using System;
using System.Threading.Tasks;
using MelbourneBlazorXamarin.Core.ViewModels;
using Microsoft.AspNetCore.Components;

namespace MelbourneBlazorXamarin.BlazorWasm.Pages
{
    public partial class PresenterDetailPage
    {
        [Inject] private PresenterDetailViewModel VM { get; set; }

        [Parameter] public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await VM.LoadPresenter(Id);
        }
    }
}