using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace ZoneSystemAssistant.Services
{
    public class UniversalUserPrefsStore : IUserPrefsStore
    {
        public ValueMode Mode
        {
            get
            {
                Enum.TryParse(Preferences.Get("MODE", ValueMode.Ev.ToString()), out ValueMode mode);
                return mode;
            }
            set => Preferences.Set("MODE", value.ToString());
        }
    }
}
