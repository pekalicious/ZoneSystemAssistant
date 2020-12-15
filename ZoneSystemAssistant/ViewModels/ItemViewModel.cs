using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ZoneSystemAssistant.Models;

namespace ZoneSystemAssistant.ViewModels
{
    public class ItemViewModel : BaseViewModel
    {
        public IItem Item { get; }
        public bool ShowEvReading => Item is Item;

        public Color Color
        {
            get => color;
            set { SetProperty(ref color, value); }
        }

        public Style ValueStyle
        {
            get => valueStyle;
            set { SetProperty(ref valueStyle, value); }
        }

        public bool IsTapped
        {
            get => isTapped;
            private set { SetProperty(ref isTapped, value); }
        }

        private readonly Page page;
        private readonly bool isEven;
        private bool isTapped;
        private Style valueStyle;
        private Color color;

        public ItemViewModel(Page page, IItem item, bool isEven)
        {
            this.page = page;
            this.isEven = isEven;

            Item = item;
            Reset();
        }

        private void UpdateBgColor()
        {
            if (IsTapped)
            {
                Color = Color.Black;
            }
            else if (isEven)
            {
                Color = Color.White;
            }
            else
            {
                Color = new Color(0.95, 0.95, 0.95);
            }
        }

        public void Toggle()
        {
            SetState(!IsTapped);
        }

        public void Reset()
        {
            SetState(false);
        }

        private void SetState(bool newState)
        {
            IsTapped = newState;
            ValueStyle = (Style)(IsTapped ? page.Resources["ValueOn"] : page.Resources["ValueOff"]);
            UpdateBgColor();
        }
    }
}
