using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib.Model
{
    public class Car
    {
        private int _id;
        private int _year;
        private string _color;

        public Car()
        {
            
        }

        public Car(int id, int year, string color)
        {
            _id = id;
            _year = year;
            _color = color;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public int Year
        {
            get => _year;
            set => _year = value;
        }

        public string Color
        {
            get => _color;
            set => _color = value;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Year)}: {Year}, {nameof(Color)}: {Color}";
        }
    }
}
