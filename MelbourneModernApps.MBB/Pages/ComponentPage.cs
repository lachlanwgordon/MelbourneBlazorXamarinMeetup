using System;
using Xamarin.Forms;

namespace MelbourneModernApps.MBB.Pages
{
    public class ComponentPage : ContentPage
    {
        public static ComponentPage Current { get; private set; }
        public ComponentPage()
        {
            Current = this;
            this.Visual = VisualMarker.Material;
        }

    }
}