using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLib.Model;

namespace ClassDemoRestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private static readonly List<Car> Cars = new List<Car>
        {
            new Car {Id=1, Model = "Amazon", Vendor = "Volvo", Price = 12345},
            new Car {Id=2, Model = "A8", Vendor = "Audi", Price = 2222222},
            new Car {Id=3, Model = "Punto", Vendor = "Fiat", Price = 102022}
        };

        /// <summary>
        /// Gets all items from list
        /// </summary>
        /// <returns>list</returns>
        // GET: api/Cars
        [HttpGet]
        public List<Car> Get()
        {
            return Cars;
        }

        /// <summary>
        /// Get specific item from list by its id
        /// </summary>
        /// <param name="id">Id to get item from</param>
        /// <returns>specific item by id</returns>
        // GET: api/Cars/5
        [HttpGet]
        [Route("{id}")]
        public Car Get(int id)
        {
            return Cars.Find(i => i.Id == id);
        }

        /// <summary>
        /// Adds item to list
        /// </summary>
        /// <param name="value">Item to add</param>
        // POST: api/Cars
        [HttpPost]
        public void Post([FromBody] Car value)
        {
            Cars.Add(value);
        }

        /// <summary>
        /// Changes values in an item
        /// </summary>
        /// <param name="id">Id of item</param>
        /// <param name="value">New values</param>
        // PUT: api/Cars/5
        [HttpPut]
        [Route("{id}")]
        public void Put(int id, [FromBody] Car value)
        {
            Car car = Get(id);
            if (car != null)
            {
                car.Id = value.Id;
                car.Vendor = value.Vendor;
                car.Model = value.Model;
                car.Price = value.Price;
            }
        }

        /// <summary>
        /// Deletes item by id
        /// </summary>
        /// <param name="id">Id of item</param>
        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            Car car = Get(id);
            Cars.Remove(car);
        }

        /// <summary>
        /// Search through models from the list and returns them.
        /// </summary>
        /// <param name="substring">model to find</param>
        /// <returns>items with specific model</returns>
        [HttpGet]
        [Route("Model/{substring}")]
        public IEnumerable<Car> GetFromSubstring(String substring)
        {
            return Cars.FindAll(i => i.Model.ToLower().Contains(substring.ToLower()));
        }

        /// <summary>
        /// Gets items with specific vendor
        /// </summary>
        /// <param name="vendor">vendor input</param>
        /// <returns>Items with specific vendor</returns>
        [HttpGet]
        [Route("Vendor/{vendor}")]
        public IEnumerable<Car> GetFromQuality(String vendor)
        {
            return Cars.FindAll(i => i.Vendor.ToLower().Contains(vendor.ToLower()));
        }

        /// <summary>
        /// Search for items with specific prices
        /// </summary>
        /// <param name="filter">Class filterItem</param>
        /// <returns>items with specific prices</returns>
        [HttpGet]
        [Route("Search")]
        public IEnumerable<Car> GetWithFilter([FromQuery] FilterCars filter)
        {
            if (filter.LowPrice != 0 && filter.HighPrice != 0)
            {
                return Cars.FindAll(i => i.Price > filter.LowPrice && i.Price < filter.HighPrice);
            }
            else if (filter.LowPrice != 0)
            {
                return Cars.FindAll(i => i.Price > filter.LowPrice);
            }
            else if (filter.HighPrice != 0)
            {
                return Cars.FindAll(i => i.Price < filter.HighPrice);
            }
            else
            {
                return new List<Car>() { new Car(204, "error", "error", 204) };
            }
        }
    }
}
