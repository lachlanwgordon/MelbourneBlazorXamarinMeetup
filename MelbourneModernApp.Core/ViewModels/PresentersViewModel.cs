using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using MelbourneModernApp.Core.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;

namespace MelbourneModernApp.Core.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Presenter> Items { get; set; } = new ObservableRangeCollection<Presenter>();
        public ICommand LoadItemsCommand => new AsyncCommand(ExecuteLoadItemsCommand);

        public ItemsViewModel()
        {
            Title = "Presenters";
        }


        public async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                await Task.Delay(500);//These are needed or the list is blank, investigate further and/or report bug
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                await Task.Delay(500);

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