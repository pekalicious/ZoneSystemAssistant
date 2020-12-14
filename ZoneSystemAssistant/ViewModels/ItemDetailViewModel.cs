using System;

using ZoneSystemAssistant.Models;

namespace ZoneSystemAssistant.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public string[] PickerValues { get { return Values.Instance.Ev; } }

        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Description;
            Item = item;
        }
    }
}
