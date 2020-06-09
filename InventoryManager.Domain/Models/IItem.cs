using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Domain.Models
{
    public interface IItem
    {
        Guid _id { get; set; }
        string Name { get; set; }
        double Weight { get; set; }
    }
}
