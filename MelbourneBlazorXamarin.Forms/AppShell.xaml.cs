using System;
using System.Collections.Generic;
using MelbourneBlazorXamarin.Views;
using Xamarin.Forms;

namespace MelbourneBlazorXamarin
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
