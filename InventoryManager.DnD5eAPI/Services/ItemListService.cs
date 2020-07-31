using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManager.DnD5eAPI.Results;
using InventoryManager.Domain.Services;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace InventoryManager.DnD5eAPI.Services
{
    public class ItemListService : IItemListService
    {
        public async Task<EquipmentListResult> ItemList(string itemUriPrefix)
        {
            using (DnD5eAPIClient client = new DnD5eAPIClient())
            {
                string uri = itemUriPrefix;

                var responseObject = await client.GetAsync<EquipmentListResult>(uri);
                
                

                return responseObject;
            }
        }
    }
}
