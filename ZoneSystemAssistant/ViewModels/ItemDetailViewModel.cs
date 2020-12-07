using System;

using ZoneSystemAssistant.Models;

namespace ZoneSystemAssistant.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Description;
            Item = item;
        }
    }
}
