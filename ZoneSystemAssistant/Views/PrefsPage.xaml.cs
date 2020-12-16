using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZoneSystemAssistant.Services;
using ZoneSystemAssistant.ViewModels;

namespace ZoneSystemAssistant.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrefsPage : ContentPage
    {
        private IUserPrefsStore UserPrefs => DependencyService.Get<IUserPrefsStore>();
        private PrefsViewModel viewModel;

        public PrefsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new PrefsViewModel();
            
            viewModel.Mode = UserPrefs.Mode;
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            UserPrefs.Mode = (ValueMode)Enum.ToObject(typeof(ValueMode), Mode.SelectedIndex);

            Navigation.PopModalAsync();
        }
    }
}