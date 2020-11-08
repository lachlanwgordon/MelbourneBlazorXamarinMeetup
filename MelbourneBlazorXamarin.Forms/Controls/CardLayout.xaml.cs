using System;
using Xamarin.Forms;
using MelbourneBlazorXamarin.Controls;


namespace MelbourneBlazorXamarin.Controls
{
    public partial class CardLayout : Frame
    {
        public object Clicked { get; set; }

        

        public void OnItemSelected(object sender, EventArgs e)
        {
            if (Clicked is EventHandler clickedEvent)
            {
                clickedEvent.Invoke(sender, e);
            }
        }

        public CardLayout()
        {
            InitializeComponent();
        }
    }
}