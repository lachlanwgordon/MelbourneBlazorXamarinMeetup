using System;
using Xamarin.Forms;
using MelbourneBlazorXamarin.Core.Models;
using MelbourneBlazorXamarin.Core.ViewModels;
using MelbourneBlazorXamarin.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MelbourneBlazorXamarin.Views
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