using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InventoryManager.DnD5eAPI
{
    public class DnD5eAPIClient : HttpClient
    {
        public DnD5eAPIClient()
        {
            this.BaseAddress = new Uri("http://dnd5eapi.co");
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            HttpResponseMessage response = await GetAsync(uri);
            string jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(jsonResponse);
        }
    }
}
