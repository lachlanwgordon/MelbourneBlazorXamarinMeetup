using System;
using Xamarin.Forms;
using MelbourneModernApp.Core.Models;
using MelbourneModernApp.Core.ViewModels;
using MelbourneModernApp.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MelbourneModernApps.Views
{
    public partial class PresentersPage : ContentPage
    {
        PresentersViewModel VM;

        public PresentersPage()
        {
            InitializeComponent();
            BindingContext = VM = Container.Current.Services.GetRequiredService<PresentersViewModel>();
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
            VM.IsBusy = true;
        }
    }
}