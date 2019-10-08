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
    public class CarOwnersController : ControllerBase
    {
        private static List<CarOwner> CarOwners = new List<CarOwner>
        {
            new CarOwner(1, "Morten", new List<Car>
            {
                new Car(10, "Fabia", "Skoda", 180000),
                new Car(11, "Octavia", "Skoda", 180000)
            }),
            new CarOwner(2, "Lucas", new List<Car>
            {
                new Car(12, "Citigo", "Skoda", 180000),
                new Car(13, "Citigo", "Skoda", 180000)
            })
        };

        // GET: api/CarOwners
        [HttpGet]
        public List<CarOwner> Get()
        {
            return CarOwners;
        }

        // GET: api/CarOwners/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CarOwners
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/CarOwners/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
