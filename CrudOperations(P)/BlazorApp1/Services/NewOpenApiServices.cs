using Newtonsoft.Json;

using CrudOperations.Models;

using static System.Net.WebRequestMethods;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Components;
using System.Web;
using BlazorApp1.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BlazorApp1.Services
{
    public class NewOpenApiServices : INewOpenApiServices
    {
        private readonly HttpClient _httpClient;

        public NewOpenApiServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Item>> GetItems()
        {
            List<Item> items = new List<Item>();

            var data = await _httpClient.GetStringAsync("https://chroniclingamerica.loc.gov/newspapers.json");
            
            if (data.Length > 0 && data != null)
            {
                var convertedData = JObject.Parse(data);
                var jdata = ((JContainer)convertedData.Root)["newspapers"];

                foreach (var item in jdata)
                {
                    items.Add(JsonConvert.DeserializeObject<Item>(Convert.ToString(item)));
                }
                return items;
            }
            return null;
        }
    }
}
