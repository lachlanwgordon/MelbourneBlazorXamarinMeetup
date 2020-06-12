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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            VM.IsBusy = true;
        }
    }
}