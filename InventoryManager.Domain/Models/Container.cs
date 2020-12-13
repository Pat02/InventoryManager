using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Domain.Models
{
    public class Container : Item
    {
        public string NickName { get; set; }
        public double MaximumCarryCapacity { get; set; }
        public double CurrentCarryCapacity { get; set; }
        public List<ContainerItem> Inventory { get; set; }
        public bool IsRootContainer { get; set; }
    }
}
