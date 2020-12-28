using System;
using System.Threading.Tasks;
using MelbourneBlazorXamarin.Core.Models;
using MelbourneBlazorXamarin.Core.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.MobileBlazorBindings;

namespace MelbourneBlazorXamarin.Forms.Views
{
    public partial class MBBPresentersPage
    {
        public MBBPresentersPage()
        {
        }
        [Inject]
        private PresentersViewModel VM { get; set; }

        [Inject]
        ShellNavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await VM.LoadItems();
        }
    }
}
