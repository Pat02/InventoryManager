using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Domain.Models
{
    public class Inventory : Trackable
    {
        public string name { get; set; }
        public List<InventoryItem> InventoryItems { get; set; }
    }
}
