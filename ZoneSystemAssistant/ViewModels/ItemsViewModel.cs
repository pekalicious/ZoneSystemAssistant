using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using ZoneSystemAssistant.ViewModels;
using Xamarin.Forms;

using ZoneSystemAssistant.Models;
using ZoneSystemAssistant.Views;

namespace ZoneSystemAssistant.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<ItemViewModel> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Zone System Assistant";
            Items = new ObservableCollection<ItemViewModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<ItemDetailPage, Item>(this, "AddItem", async (obj, item) =>
            {
                Items.Add(new ItemViewModel(item));
                await DataStore.AddItemAsync(item);
            });
            MessagingCenter.Subscribe<ItemDetailPage, Item>(this, "UpdateItem", async (obj, item) =>
            {
                await DataStore.UpdateItemAsync(item);
            });
        }

        public async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                for (int i = 0; i < 47; i++)
                {
                    Items.Add(new ItemViewModel(new MockItem()));
                }
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    var index = item.Ev + 6 + 10;
                    Items[index] = new ItemViewModel(item);
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
            Items.Clear();
            await DataStore.ClearAll();
        }
    }
}