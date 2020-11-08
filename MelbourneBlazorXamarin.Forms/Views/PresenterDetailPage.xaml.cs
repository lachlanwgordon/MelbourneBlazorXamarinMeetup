using System;
using System.Collections.Generic;
using MelbourneBlazorXamarin.Core.Models;
using MelbourneBlazorXamarin.Core.Services;
using MelbourneBlazorXamarin.Core.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MelbourneBlazorXamarin.Views
{
    [QueryProperty(nameof(presenter), nameof(presenter))]
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