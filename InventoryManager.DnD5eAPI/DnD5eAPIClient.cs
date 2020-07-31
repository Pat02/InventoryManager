using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.IO;

namespace InventoryManager.DnD5eAPI
{
    public class DnD5eAPIClient : HttpClient
    {
        private JsonSerializer JsonSerializer = new JsonSerializer();
        public DnD5eAPIClient()
        {
            this.BaseAddress = new Uri("http://dnd5eapi.co");
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            HttpResponseMessage response = await GetAsync(uri);
            string jsonResponse = await response.Content.ReadAsStringAsync();
            JsonReader Jreader = new JsonTextReader(new StringReader(jsonResponse));

            return JsonSerializer.Deserialize<T>(Jreader);
        }
    }
}
