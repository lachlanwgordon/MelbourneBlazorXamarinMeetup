using System;
using System.Threading.Tasks;
using MelbourneBlazorXamarin.Core.Models;
using MelbourneBlazorXamarin.Core.ViewModels;
using Microsoft.AspNetCore.Components;

namespace MelbourneBlazorXamarin.BlazorWasm.Pages
{
    public partial class PresentersPage
    {
        public PresentersPage()
        {
        }
        [Inject]
        private PresentersViewModel VM { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await VM.LoadItems();
        }
    }
}
