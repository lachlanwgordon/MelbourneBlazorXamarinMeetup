using System;
using System.Threading.Tasks;
using MelbourneModernApp.Core.Models;
using MelbourneModernApp.Core.ViewModels;
using Microsoft.AspNetCore.Components;

namespace MelbourneModernApps.BlazorWasm.Pages
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
