using System;
using System.Collections.Generic;
using System.Text;
using ZoneSystemAssistant.Models;

namespace ZoneSystemAssistant.ViewModels
{
    public class ItemViewModel
    {
        public Item Item { get; private set; }
        public bool ShowEvReading { get { return Item.Ev > 0; } }

        public ItemViewModel(Item item)
        {
            Item = item;
        }
    }
}
