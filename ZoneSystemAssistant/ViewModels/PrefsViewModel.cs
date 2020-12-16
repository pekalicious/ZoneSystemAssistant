using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using ZoneSystemAssistant.Services;
using ZoneSystemAssistant.Utils;

namespace ZoneSystemAssistant.ViewModels
{
    public class PrefsViewModel : BaseViewModel
    {
        private ValueMode mode;
        public ValueMode Mode
        {
            get => mode;
            set => SetProperty(ref mode, value);
        }

        public string[] Modes => Enum.GetNames(typeof(ValueMode)).Select(StringExtensions.SplitCamelCase).ToArray();
    }
}
