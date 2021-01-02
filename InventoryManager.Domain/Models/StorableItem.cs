using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Domain.Models
{
    public class StorableItem : Item
    {
        public bool ContainerItemWeightCountsToContainerTotal(ContainerItem containerItem)
        {
            if (containerItem.ItemLocation == ItemLocation.inContainer) return true;
            else return false;
        }
    }
}
