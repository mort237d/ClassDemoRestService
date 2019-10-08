using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib.Model
{
    public class CarOwner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Car> Cars { get; set; }

        public CarOwner(int id, string name, List<Car> cars)
        {
            Id = id;
            Name = name;
            Cars = cars;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Cars: {Cars}";
        }
    }
}
