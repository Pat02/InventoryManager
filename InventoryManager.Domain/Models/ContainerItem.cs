using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Domain.Models
{
    public class ContainerItem : StorableItem, IStorable
    {
        public ContainerItem()
        {
        }

        public ContainerItem(ItemDefinition item, int quantity)
        {
            ItemDefinition = item;
            Quantity = quantity;
        }

        public ItemDefinition ItemDefinition { get; set; }
        public int Quantity { get; set; }

        public ItemLocation ItemLocation { get; set; } = ItemLocation.inContainer;

        public double GetWeightForContainer()
        {
            return ItemDefinition.Weight * Quantity;
        }

        public double GetWeightIncludingStrappedItems()
        {
            return GetWeightForContainer();
        }
    }

    public enum ItemLocation
    {
        inContainer,
        strappedToOutside
    }
}
