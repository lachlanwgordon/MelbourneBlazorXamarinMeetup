using System;
using System.Collections.Generic;
using MelbourneModernApp.Core.Models;
using MelbourneModernApp.Core.Services;
using MelbourneModernApp.Core.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MelbourneModernApps.Views
{
    [QueryProperty("presenter", "presenter")]
    public partial class PresenterDetailPage : ContentPage
    {
        public string presenter { get; set; }
        PresenterDetailViewModel VM;
        public PresenterDetailPage()
        {
            InitializeComponent();
            BindingContext = VM = Container.Current.Services.GetRequiredService<PresenterDetailViewModel>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if(!string.IsNullOrEmpty(presenter))
                await VM.LoadPresenter(presenter);
        }
    }
}