using InventoryManager.DnD5eAPI.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.DnD5eAPI.Services
{
    public class ItemService : IItemService
    {
        public async Task<ItemResult> GetItem(string url)
        {
            using (DnD5eAPIClient client = new DnD5eAPIClient())
            {
                string uri = url;

                var responseObject = await client.GetAsync<ItemResult>(uri);

                return responseObject;
            }
        }
    }
}
