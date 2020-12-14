using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ZoneSystemAssistant.Models;

namespace ZoneSystemAssistant.ViewModels
{
    public class ItemViewModel
    {
        public IItem Item { get; private set; }
        public bool ShowEvReading { get { return Item.Ev > 0; } }
        public Color Color { get; private set; }

        public ItemViewModel(IItem item, bool isEven)
        {
            Item = item;
            if (isEven)
            {
                Color = Color.White;
            }
            else
            {
                Color = new Color(0.95, 0.95, 0.95);
            }
        }
    }
}
