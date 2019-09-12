using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLib.Model;

namespace ClassDemoRestService.Controllers
{
    [Route("api/localitems")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private static List<Item> items = new List<Item>()
        {
            new Item(1,"Bread","Low",33),
            new Item(2,"Bread","Middle",21),
            new Item(3,"Beer","low",70.5),
            new Item(4,"Soda","High",21.4),
            new Item(5,"Milk","Low",55.8)
        };

        // GET: api/Items
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return items;
        }

        // GET: api/Items/5
        [HttpGet]
        [Route("{id}")]
        public Item Get(int id)
        {
            return items.Find(i => i.Id == id);
        }

        // POST: api/Items
        [HttpPost]
        public void Post([FromBody] Item value)
        {
            items.Add(value);
        }

        // PUT: api/Items/5
        [HttpPut]
        [Route("{id}")]
        public void Put(int id, [FromBody] Item value)
        {
            Item item = Get(id);
            if (item != null)
            {
                item.Id = value.Id;
                item.Name = value.Name;
                item.Quality = value.Quality;
                item.Quantity = value.Quantity;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            Item item = Get(id);
            items.Remove(item);
        }

        [HttpGet]
        [Route("Name/{substring}")]
        public IEnumerable<Item> GetFromSubstring(String substring)
        {
            return items.FindAll(i => i.Name.ToLower().Contains(substring.ToLower()));
        }

        [HttpGet]
        [Route("Quality/{quality}")]
        public IEnumerable<Item> GetFromQuality(String quality)
        {
            return items.FindAll(i => i.Quality.ToLower().Contains(quality.ToLower()));
        }

        [HttpGet]
        [Route("Search")]
        public IEnumerable<Item> GetWithFilter([FromQuery] FilterItem filter)
        {
            if (filter.LowQuantity != 0 && filter.HighQuantity != 0)
            {
                return items.FindAll(i => i.Quantity > filter.LowQuantity && i.Quantity < filter.HighQuantity);
            }
            else if (filter.LowQuantity != 0)
            {
                return items.FindAll(i => i.Quantity > filter.LowQuantity);
            }
            else if (filter.HighQuantity != 0)
            {
                return items.FindAll(i => i.Quantity < filter.HighQuantity);
            }
            else
            {
                return new List<Item>(){new Item(204, "error", "error", 204)};
            }
        }
    }
}
