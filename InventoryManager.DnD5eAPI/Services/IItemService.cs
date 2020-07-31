using InventoryManager.DnD5eAPI.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.DnD5eAPI.Services
{
    public interface IItemService
    {
        public Task<ItemResult> GetItem(string url);
    }
}
