using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ZoneSystemAssistant.Models;
using ZoneSystemAssistant.ViewModels;

namespace ZoneSystemAssistant.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        bool isNewItem;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            isNewItem = false;

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();
            isNewItem = true;

            var item = new Item
            {
                Ev = 0,
                Description = "Shadows"
            };

            BindingContext = this.viewModel = new ItemDetailViewModel(item);
            DescEntry.ReturnCommand = new Command(() => Save());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await Task.Delay(50);
            EvEntry.Focus();
        }

        void Save_Clicked(object sender, EventArgs e)
        {
            Save();
        }

        async void Save()
        {
            this.viewModel.Item.Ev = int.Parse(EvEntry.Text);
            this.viewModel.Item.Description = DescEntry.Text;

            if (isNewItem)
            {
                MessagingCenter.Send(this, "AddItem", viewModel.Item);
            }
            else
            {
                MessagingCenter.Send(this, "UpdateItem", viewModel.Item);
            }
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void DescEntry_OnFocused(object sender, FocusEventArgs e)
        {
            DescEntry.CursorPosition = 0;
            DescEntry.SelectionLength = DescEntry.Text.Length;
        }

        private void EvEntry_OnFocused(object sender, FocusEventArgs e)
        {
            EvEntry.CursorPosition = 0;
            EvEntry.SelectionLength = EvEntry.Text.Length;
        }
    }
}