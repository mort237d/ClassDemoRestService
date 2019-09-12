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
        private static List<Car> data = new List<Car>()
        {
            new Car(12, 2018, "rød"),
            new Car(14, 2016, "blå")
        };

        // GET: api/Cars
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return data;
        }

        // GET: api/Cars/5
        [HttpGet("{id}", Name = "GetCar")]
        public Car Get(int id)
        {
            return data.Find( c => c.Id == id);
        }

        // POST: api/Cars
        [HttpPost]
        public void Post([FromBody] Car value)
        {
            data.Add(value);
        }

        // PUT: api/Cars/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Car value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Car car = Get(id);
            if (car != null) data.Remove(car);
            
        }
    }
}
