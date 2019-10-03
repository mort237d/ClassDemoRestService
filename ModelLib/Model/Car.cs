using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib.Model
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Vendor { get; set; }
        public int Price { get; set; }

        public Car(int id, string model, string vendor, int price)
        {
            Id = id;
            Model = model;
            Vendor = vendor;
            Price = price;
        }

        public Car()
        {
        }

        public override string ToString()
        {
            return $"Id: {Id}, Model: {Model}, Vendor: {Vendor}, Price: {Price}";
        }
    }
}
