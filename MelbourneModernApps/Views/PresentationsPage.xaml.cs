using MelbourneModernApp.Core.ViewModels;
using Xamarin.Forms;


namespace MelbourneModernApps.Views
{
    public partial class PresentationsPage : ContentPage
    {
        PresentationsViewModel viewModel;
        public PresentationsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new PresentationsViewModel();

        }
        string PresenterId;
        public PresentationsPage(string presenterId) : this()
        {
            BindingContext = viewModel = new PresentationsViewModel(presenterId);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.IsBusy = true;
        }
    }
}