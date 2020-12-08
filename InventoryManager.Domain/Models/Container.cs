using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Domain.Models
{
    public class Container : Item
    {
        public double MaximumCarryCapacity { get; set; }
        public double CurrentCarryCapacity { get; set; }
        public List<ContainerItems> Inventory { get; set; }
    }
}
