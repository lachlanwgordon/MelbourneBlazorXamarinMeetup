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
        public ObservableRangeCollection<Presenter> Items { get; set; } = new ObservableRangeCollection<Presenter>();
        public ICommand LoadItemsCommand => new AsyncCommand(ExecuteLoadItemsCommand);

        public IDataStore<Presenter> DataStore;


        public PresentersViewModel(IDataStore<Presenter> dataStore)
        {
            DataStore = dataStore;
        }

        public async Task ExecuteLoadItemsCommand()
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
    }
}