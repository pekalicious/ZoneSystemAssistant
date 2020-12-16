using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ZoneSystemAssistant.ViewModels;
using Xamarin.Forms;

using ZoneSystemAssistant.Views;

namespace ZoneSystemAssistant.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private readonly Page page;
        public ObservableCollection<ItemViewModel> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel(Page page)
        {
            this.page = page;
            Title = "Zone System Assistant";
            Items = new ObservableCollection<ItemViewModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        public async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                int j = 0;
                for (int i = 0; i < 10; i++)
                {
                    Items.Add(new ItemViewModel(page, j++ % 2 == 0));
                }
                foreach (var evValue in Values.Instance.Ev)
                {
                    Items.Add(new ItemViewModel(page, j++ % 2 == 0, evValue));
                }
                for (int i = 0; i < 10; i++)
                {
                    Items.Add(new ItemViewModel(page, j++ % 2 == 0));
                }
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

        public async Task ResetItems()
        {
            //Items.Clear();
            //await DataStore.ClearAll();
            foreach (var item in Items)
            {
                item.Reset();
            }
        }
    }
}