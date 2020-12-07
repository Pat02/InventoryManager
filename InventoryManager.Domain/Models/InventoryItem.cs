﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Domain.Models
{
    public class InventoryItem : Trackable
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }
    }
}
