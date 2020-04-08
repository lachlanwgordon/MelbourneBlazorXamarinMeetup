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
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (Item)layout.BindingContext;
            await Shell.Current.Navigation.PushAsync(new ItemDetailPage(item));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new NavigationPage(new ItemDetailPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //viewModel.LoadItemsCommand.Execute(null);

            //if (viewModel.Items.Count == 0)
            viewModel.IsBusy = true;
        }
    }
}