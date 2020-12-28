﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Domain.Models
{
    public class ContainerItem : Trackable
    {
        public ContainerItem()
        {
        }

        public ContainerItem(Item item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }

        public Item Item { get; set; }
        public int Quantity { get; set; }

        public ItemLocation ItemLocation { get; set; } = ItemLocation.inContainer;

        public double ItemWeightSubtotal
        {
            get
            {
                return Item.Weight * Quantity;
            }
        }
    }

    public enum ItemLocation
    {
        inContainer,
        strappedToOutside
    }
}