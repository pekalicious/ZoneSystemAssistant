using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ZoneSystemAssistant.Models;
using ZoneSystemAssistant.Views;
using ZoneSystemAssistant.ViewModels;

namespace ZoneSystemAssistant.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        private static bool firstTime = true;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        public async void OnItemSelected(object sender, EventArgs eventArgs)
        {
            var layout = (BindableObject)sender;
            var itemViewModel = (ItemViewModel)layout.BindingContext;
            if (itemViewModel.ShowEvReading && itemViewModel.Item is Item item)
            {
                await Navigation.PushModalAsync(new NavigationPage(new ItemDetailPage(new ItemDetailViewModel(item))));
            }
        }

        async void Reset_Clicked(object sender, EventArgs e)
        {
            await viewModel.ResetItems();
            await viewModel.ExecuteLoadItemsCommand();
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Task.Delay(50);
                ItemsCollectionView.ScrollTo(viewModel.Items[15], -1, ScrollToPosition.Start, false);
                firstTime = false;
            });
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ItemDetailPage()));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await viewModel.ExecuteLoadItemsCommand();

            if (firstTime)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Task.Delay(50);
                    ItemsCollectionView.ScrollTo(viewModel.Items[15], -1, ScrollToPosition.Start, false);
                    firstTime = false;
                });
            }
        }
    }
}