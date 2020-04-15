using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MelbourneModernApps.Views;
using MelbourneModernApp.Core.Models;
using MelbourneModernApp.Core.ViewModels;

namespace MelbourneModernApps.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class PresentersPage : ContentPage
    {
        ItemsViewModel viewModel;

        public PresentersPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (Presenter)layout.BindingContext;
            await Shell.Current.Navigation.PushAsync(new PresenterDetailPage(item));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new PresenterDetailPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.IsBusy = true;
        }
    }
}