using System;
using Microsoft.AspNetCore.Components;

namespace MelbourneModernApps.MBB.Pages
{
    public partial class NavView
    {
        [Parameter]
        public RenderFragment Contents { get; set; }

        [Parameter]
        public EventCallback NavigatingTo { get; set; }

        public string NavigationParameter { get; set; }

        public static NavView Current { get; set; }
        public NavView()
        {
            Current = this;
        }

        public void OnNavigationTo (string parameter)
        {
            NavigationParameter = parameter;
            if (NavigatingTo.HasDelegate)
                NavigatingTo.InvokeAsync(parameter);
        }
    }
}