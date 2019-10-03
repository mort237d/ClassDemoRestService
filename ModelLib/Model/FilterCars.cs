using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib.Model
{
    public class FilterCars
    {
        private int _lowPrice;
        private int _highPrice;

        public FilterCars()
        {
            
        }

        public int LowPrice
        {
            get => _lowPrice;
            set => _lowPrice = value;
        }

        public int HighPrice
        {
            get => _highPrice;
            set => _highPrice = value;
        }
    }
}
