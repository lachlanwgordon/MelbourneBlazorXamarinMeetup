using System;
using System.Threading.Tasks;

namespace MelbourneModernApps.MBB.Pages
{
    public partial class PresentersPage
    {
        public PresentersPage()
        {
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await VM.LoadItems();
        }
    }
}