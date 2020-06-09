using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManager.Domain.Services;

namespace InventoryManager.DnD5eAPI.Services
{
    public class ItemListService : IItemListService
    {
        public Task<Dictionary<string, string>> ItemList(string itemUriPrefix)
        {
            string uri = "equipment";

            Dictionary<string,string>
        }
    }
}
