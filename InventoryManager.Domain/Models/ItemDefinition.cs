using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Domain.Models
{
    public class ItemDefinition : Item
    {
        public string Name { get; set; }
        public double Weight { get; set; }
    }
}
