using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZoneSystemAssistant.Services;
using ZoneSystemAssistant.ViewModels;

namespace ZoneSystemAssistant.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        private IUserPrefsStore UserPrefs => DependencyService.Get<IUserPrefsStore>();
        ItemsViewModel viewModel;

        private static bool firstTime = true;
        private ValueMode currentMode;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel(this);
        }

        public async void OnItemSelected(object sender, EventArgs eventArgs)
        {
            var layout = (BindableObject)sender;
            var itemViewModel = (ItemViewModel)layout.BindingContext;
            if (itemViewModel.IsValue)
            {
                itemViewModel.Toggle();
            }
        }

        async void Reset_Clicked(object sender, EventArgs e)
        {
            await ResetEverything();
        }

        private async Task ResetEverything()
        {
            await viewModel.ResetItems();
            await viewModel.ExecuteLoadItemsCommand(this.currentMode);
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Task.Delay(50);
                ItemsCollectionView.ScrollTo(viewModel.Items[15], -1, ScrollToPosition.Start, false);
                firstTime = false;
            });
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (firstTime)
            {
                firstTime = false;

                this.currentMode = UserPrefs.Mode;
                await viewModel.ExecuteLoadItemsCommand(this.currentMode);

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Task.Delay(50);
                    ItemsCollectionView.ScrollTo(viewModel.Items[15], -1, ScrollToPosition.Start, false);
                });
            }
            else
            {
                if (this.currentMode != UserPrefs.Mode)
                {
                    this.currentMode = UserPrefs.Mode;
                    await ResetEverything();
                }
            }
        }

        private void Config_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new PrefsPage()));
        }
    }
}