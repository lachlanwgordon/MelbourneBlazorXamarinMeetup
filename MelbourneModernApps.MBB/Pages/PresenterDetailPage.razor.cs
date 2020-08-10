using System;
using System.Threading.Tasks;
using MelbourneModernApp.Core.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.MobileBlazorBindings.Elements;

namespace MelbourneModernApps.MBB.Pages
{
    public partial class PresenterDetailPage
    {
        public PresenterDetailViewModel VM { get; set; }

        [Parameter]
        public string Id { get; set; }
        Microsoft.MobileBlazorBindings.Elements.Frame PictureFrame { get; set; }
        Image Picture { get; set; }

        public PresenterDetailPage()
        {
            VM = App.Host.Services.GetRequiredService<PresenterDetailViewModel>();
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await VM.LoadPresenter(Id);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await  base.OnAfterRenderAsync(firstRender);
            //if(VM.Item != null)
            //{
            //    PictureFrame.NativeControl.CornerRadius = (float)Picture.NativeControl.Height / 2;
            //    PictureFrame.NativeControl.WidthRequest = (float)Picture.NativeControl.Height;
            //}
        }
    }
}