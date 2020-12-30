using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.WPF.UI.ViewModels
{
    public class StorableBaseViewModel : BaseViewModel, IStorableViewModel
    {
        public double GetWeightForContainer()
        {
            throw new NotImplementedException();
        }

        public double GetWeightIncludingStrappedItems()
        {
            throw new NotImplementedException();
        }
    }
}
