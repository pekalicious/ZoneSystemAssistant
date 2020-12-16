using System;
using System.Collections.Generic;
using System.Text;

namespace ZoneSystemAssistant.Services
{
    public enum ValueMode
    {
        Ev,
        ShutterSpeed,
        Aperture
    }

    public interface IUserPrefsStore
    {
        ValueMode Mode { get; set; }
    }
}
