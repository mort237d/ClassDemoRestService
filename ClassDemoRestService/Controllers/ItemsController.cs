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

        /// <summary>
        /// Gets all items from list
        /// </summary>
        /// <returns>list</returns>
        // GET: api/Items
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return items;
        }

        /// <summary>
        /// Get specific item from list by its id
        /// </summary>
        /// <param name="id">Id to get item from</param>
        /// <returns>specific item by id</returns>
        // GET: api/Items/5
        [HttpGet]
        [Route("{id}")]
        public Item Get(int id)
        {
            return items.Find(i => i.Id == id);
        }

        /// <summary>
        /// Adds item to list
        /// </summary>
        /// <param name="value">Item to add</param>
        // POST: api/Items
        [HttpPost]
        public void Post([FromBody] Item value)
        {
            items.Add(value);
        }

        /// <summary>
        /// Changes values in an item
        /// </summary>
        /// <param name="id">Id of item</param>
        /// <param name="value">New values</param>
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

        /// <summary>
        /// Deletes item by id
        /// </summary>
        /// <param name="id">Id of item</param>
        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            Item item = Get(id);
            items.Remove(item);
        }

        /// <summary>
        /// Search through names from the list and returns them.
        /// </summary>
        /// <param name="substring">name to find</param>
        /// <returns>items with specific name</returns>
        [HttpGet]
        [Route("Name/{substring}")]
        public IEnumerable<Item> GetFromSubstring(String substring)
        {
            return items.FindAll(i => i.Name.ToLower().Contains(substring.ToLower()));
        }

        /// <summary>
        /// Gets items with specific quality
        /// </summary>
        /// <param name="quality">quality input</param>
        /// <returns>Items with specific quality</returns>
        [HttpGet]
        [Route("Quality/{quality}")]
        public IEnumerable<Item> GetFromQuality(String quality)
        {
            return items.FindAll(i => i.Quality.ToLower().Contains(quality.ToLower()));
        }

        /// <summary>
        /// Search for items sith specific quantities
        /// </summary>
        /// <param name="filter">Class filterItem</param>
        /// <returns>items with specific quantities</returns>
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
