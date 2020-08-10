using System;
using MelbourneModernApps.MBB.Pages;
using Xamarin.Forms;

namespace MelbourneModernApps.MBB
{
    public partial class AppShell
    {
        public AppShell()
        {
            Routing.RegisterRoute("presenters/detail", typeof(ComponentPage));


        }
    }
}