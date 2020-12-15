﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ZoneSystemAssistant.ViewModels;
using Xamarin.Forms;

using ZoneSystemAssistant.Models;
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

            MessagingCenter.Subscribe<ItemDetailPage, Item>(this, "AddItem", async (obj, item) =>
            {
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
                int j = 0;
                for (int i = 0; i < 10; i++)
                {
                    Items.Add(new ItemViewModel(page, new MockItem(), j++ % 2 == 0));
                }
                foreach (var evValue in Values.Instance.Ev)
                {
                    Items.Add(new ItemViewModel(page, new Item() { Ev = int.Parse(evValue) }, j++ % 2 == 0));
                }
                for (int i = 0; i < 10; i++)
                {
                    Items.Add(new ItemViewModel(page, new MockItem(), j++ % 2 == 0));
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