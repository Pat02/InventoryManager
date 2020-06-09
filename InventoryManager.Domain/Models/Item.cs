using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Domain.Models
{
    public class Item : IItem
    {
        public Guid _id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
    }
}
