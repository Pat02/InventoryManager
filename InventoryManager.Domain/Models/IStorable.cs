using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Domain.Models
{
    public interface IStorable
    {
        public double GetWeightForContainer();
        public double GetWeightIncludingStrappedItems();
    }
}
