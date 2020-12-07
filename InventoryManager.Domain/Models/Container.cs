using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Domain.Models
{
    public class Container : Trackable, IItem
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double MaximumCarryCapacity { get; set; }
        public double CurrentCarryCapacity { get; set; }
        public Inventory Inventory { get; set; }
    }
}
