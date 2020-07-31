using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManager.DnD5eAPI.Results;

namespace InventoryManager.Domain.Services
{
    public interface IItemListService
    {
        Task<EquipmentListResult> ItemList(string itemUriPrefix);
    }
}
