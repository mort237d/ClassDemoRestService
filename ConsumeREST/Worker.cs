using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ModelLib.Model;
using Newtonsoft.Json;

namespace ConsumeREST
{
    internal class Worker
    {
        public void Start()
        {
            foreach (var item in GetAllItemsAsync().Result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(GetOneItemsAsync(3).Result);

            Console.WriteLine(PutItemAsync(3, new Item(3, "Beer", "Low", 33)).Result.IsSuccessStatusCode);

            Console.WriteLine(PostItemAsync(new Item(1, "Bread", "Low", 33)).Result.IsSuccessStatusCode);

            //Console.WriteLine(DeleteItemAsync(2).Result.StatusCode);
        }

        public async Task<IList<Item>> GetAllItemsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync("https://itemservice-mort237d.azurewebsites.net/api/localitems");
                IList<Item> cList = JsonConvert.DeserializeObject<IList<Item>>(content);
                return cList;
            }
        }

        public async Task<Item> GetOneItemsAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync("https://itemservice-mort237d.azurewebsites.net/api/localitems/" + id);
                Item item = JsonConvert.DeserializeObject<Item>(content);
                return item;
            }
        }

        public async Task<HttpResponseMessage> PutItemAsync(int id, Item itemInput)
        {
            using (HttpClient client = new HttpClient())
            {
                String jsonStr = JsonConvert.SerializeObject(itemInput);
                StringContent strContent = new StringContent(jsonStr, Encoding.UTF8, "application/json");
                HttpResponseMessage content = await client.PutAsync("https://itemservice-mort237d.azurewebsites.net/api/localitems/" + id, strContent);
                return content;
            }
        }

        public async Task<HttpResponseMessage> PostItemAsync(Item itemInput)
        {
            using (HttpClient client = new HttpClient())
            {
                String jsonStr = JsonConvert.SerializeObject(itemInput);
                StringContent strContent = new StringContent(jsonStr, Encoding.UTF8, "application/json");
                HttpResponseMessage content = await client.PostAsync("https://itemservice-mort237d.azurewebsites.net/api/localitems", strContent);
                return content;
            }
        }

        public async Task<HttpResponseMessage> DeleteItemAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage content = await client.DeleteAsync("https://itemservice-mort237d.azurewebsites.net/api/localitems/" + id);
                return content;
            }
        }
    }
}