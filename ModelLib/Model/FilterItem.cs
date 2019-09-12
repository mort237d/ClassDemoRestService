using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib.Model
{
    public class FilterItem
    {
        private int _lowQuantity;
        private int _highQuantity;

        public FilterItem()
        {
            
        }

        public FilterItem(int lowQuantity, int highQuantity)
        {
            _lowQuantity = lowQuantity;
            _highQuantity = highQuantity;
        }

        public int LowQuantity
        {
            get => _lowQuantity;
            set => _lowQuantity = value;
        }

        public int HighQuantity
        {
            get => _highQuantity;
            set => _highQuantity = value;
        }
    }
}
