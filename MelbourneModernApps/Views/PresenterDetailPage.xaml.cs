using System;
using System.Collections.Generic;
using System.ComponentModel;
using MelbourneModernApp.Core.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MelbourneModernApps.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class PresenterDetailPage : ContentPage
    {
        public PresenterDetailPage()
        {
            InitializeComponent();
        }

        Presenter Item;

        public PresenterDetailPage(Presenter item)
        {
            InitializeComponent();
            Item = item;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            var success = await VM.Save();
            if(success)
                await Navigation.PopAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if(Item != null)
                await VM.LoadPresenter(Item.Id);
            
        }
    }
}