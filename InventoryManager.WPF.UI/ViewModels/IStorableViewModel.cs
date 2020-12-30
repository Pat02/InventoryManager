using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.WPF.UI.ViewModels
{
    public interface IStorableViewModel
    {
        public double GetWeightForContainer();
        public double GetWeightIncludingStrappedItems();

    }
}
