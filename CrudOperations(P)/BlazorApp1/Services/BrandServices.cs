using Newtonsoft.Json;

using CrudOperations.Models;

using static System.Net.WebRequestMethods;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Components;
using System.Web;

namespace BlazorApp1.Services
{
    public class BrandServices : IBrandServices
    {
        private readonly HttpClient _httpClient;
        private object httpClient;

        public BrandServices(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<List<Brand>> GetBrands(string? query)
        {
            List<Brand> brands = new List<Brand>();

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            if (queryString != null)
            {
                queryString["q"] = query;
            }


            var data = await _httpClient.GetStringAsync($"api/Brand?{queryString.ToString()}");
            
            if (data.Length>0 && data != null)
            {
                var convertedData = JObject.Parse(data);
                var jdata = ((Newtonsoft.Json.Linq.JContainer)convertedData.Root)["data"];
                
                foreach(var item in jdata)
                {
                    brands.Add(JsonConvert.DeserializeObject<Brand>(Convert.ToString(item)));
                }
                return brands;
            }
            return null;
        }

        public async Task<List<Brand>> PostBrand(Brand brand)
        {
            //brand.ID = 0;
            List<Brand> brands = new List<Brand>();
            await _httpClient.PostJsonAsync("api/Brand", brand);
            return brands;
        }


        public async Task<Brand> GetBrand(int id)
        {
            var data = await _httpClient.GetStringAsync($"api/Brand/{id}");

            if (data != null && data.Length > 0)
            {
                var convertedData = JObject.Parse(data);
                var jdata = ((Newtonsoft.Json.Linq.JContainer)convertedData.Root)["data"];

                return JsonConvert.DeserializeObject<Brand>(Convert.ToString(jdata[0]));
            }

            return null;
        }

        public async Task PutBrand(int id, Brand brand)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Brand?id=" + id, brand);
        }

        public async Task<bool> DeleteBrand(int id)
        {
            try
            {
          
                var res = await _httpClient.DeleteAsync("api/Brand/"+id);
                if (res.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {

                return false;
            }
            return false;
        }



        
    }
}
