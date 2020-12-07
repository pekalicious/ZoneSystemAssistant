using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pekalicious.ZoneSystemAssistant.Views;
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

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
            ItemsCollectionView.ItemTemplate = new DataTemplate(() =>
            {
                Grid grid = new Grid
                {
                    Padding = new Thickness(10, 0, 0, 0),
                    ColumnSpacing = 0,
                    Margin = 0,
                    RowDefinitions = new RowDefinitionCollection
                    {
                        new RowDefinition() { Height = GridLength.Star }
                    },
                    ColumnDefinitions = new ColumnDefinitionCollection
                    {
                        new ColumnDefinition() { Width = GridLength.Star }, 
                        new ColumnDefinition() { Width = new GridLength(5, GridUnitType.Star) }
                    }
                };
                
                Label evLabel = new Label();
                evLabel.LineBreakMode = LineBreakMode.NoWrap;
                //d: Text = "{Binding .}"
                evLabel.FontSize = 32;
                evLabel.FontAttributes = FontAttributes.Bold;
                evLabel.VerticalOptions = LayoutOptions.Center;
                evLabel.HorizontalTextAlignment = TextAlignment.Start;
                evLabel.SetBinding(Label.TextProperty, "Ev");
                grid.Children.Add(evLabel, 0, 0);

                Label descLabel = new Label();
                //d: Text = "Item descripton"
                descLabel.SetBinding(Label.TextProperty, "Description");
                descLabel.LineBreakMode = LineBreakMode.NoWrap;
                descLabel.FontSize = 22;
                descLabel.VerticalOptions = LayoutOptions.Center;
                descLabel.HorizontalTextAlignment = TextAlignment.Start;
                grid.Children.Add(descLabel, 1, 0);

                grid.GestureRecognizers.Add(new TapGestureRecognizer() { NumberOfTapsRequired = 1, TappedCallback = OnItemSelected });
                return grid;
            });
        }

        async void OnItemSelected(View view, object o)
        {
            var layout = (BindableObject)view;
            var item = (Item)layout.BindingContext;
            await Navigation.PushModalAsync(new NavigationPage(new ItemDetailPage(new ItemDetailViewModel(item))));
        }

        async void Reset_Clicked(object sender, EventArgs e)
        {
            await viewModel.ResetItems();
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ItemDetailPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}