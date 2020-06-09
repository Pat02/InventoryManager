using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Domain.Services
{
    public interface IItemListService
    {
        Task<Dictionary<string, string>> ItemList(string itemUriPrefix);
    }
}
