using System;
using System.Collections.Generic;
using MelbourneModernApps.Views;
using Xamarin.Forms;

namespace MelbourneModernApps
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("presenters/detail", typeof(PresenterDetailPage));
        }
    }
}
