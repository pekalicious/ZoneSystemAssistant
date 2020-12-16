using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ZoneSystemAssistant.ViewModels;
using Xamarin.Forms;
using ZoneSystemAssistant.Services;
using ZoneSystemAssistant.Views;

namespace ZoneSystemAssistant.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private readonly Page page;
        public ObservableCollection<ItemViewModel> Items { get; set; }

        public ItemsViewModel(Page page)
        {
            this.page = page;
            Title = "Zone System Assistant";
            Items = new ObservableCollection<ItemViewModel>();
        }

        public async Task ExecuteLoadItemsCommand(ValueMode mode)
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
                foreach (string value in GetValuesBasedOnUserPrefs(mode))
                {
                    Items.Add(new ItemViewModel(page, j++ % 2 == 0, value));
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

        private List<string> GetValuesBasedOnUserPrefs(ValueMode mode)
        {
            switch (mode)
            {
                case ValueMode.Ev: return Values.Instance.Ev.ToList();
                case ValueMode.ShutterSpeed: return Values.Instance.ShutterSpeeds.ToList();
                case ValueMode.Aperture: return Values.Instance.Apertures.ToList();
            }

            return Values.Instance.Ev.ToList();
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