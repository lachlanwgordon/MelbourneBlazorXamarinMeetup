using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using MelbourneModernApp.Core.Models;
using MelbourneModernApp.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using MvvmHelpers;
using MvvmHelpers.Commands;

namespace MelbourneModernApp.Core.ViewModels
{
    public class PresentersViewModel : BaseViewModel
    {
        IDataStore<Presenter> DataStore;
        INavigationService NavigationService;

        public ObservableRangeCollection<Presenter> Items { get; set; } = new ObservableRangeCollection<Presenter>();
        public ICommand LoadItemsCommand => new AsyncCommand(LoadItems);
        public ICommand OpenPresenterCommand => new AsyncCommand<Presenter>(OpenPresenter);

        public PresentersViewModel(IDataStore<Presenter> dataStore, INavigationService navigationService)
        {
            DataStore = dataStore;
            NavigationService = navigationService;
        }

        public async Task LoadItems()
        {
            IsBusy = true;

            try
            {
                await Task.Delay(500);//These are needed or the list is blank, investigate further and/or report bug
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                Items.AddRange(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task OpenPresenter(Presenter presenter = null)
        {
            if (presenter == null)
            {
                await NavigationService.NavigateToPageAsync($"presenters/detail");
            }
            else
            {
                await NavigationService.NavigateToPageAsync($"presenters/detail", "presenter", presenter.Id );
            }
        }
    }
}