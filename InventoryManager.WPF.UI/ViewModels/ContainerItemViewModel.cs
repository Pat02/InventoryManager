using InventoryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.WPF.UI.ViewModels
{
    class ContainerItemViewModel : ViewModelBase
    {
        private ContainerItem _containerItem;

        public ContainerItemViewModel(ContainerItem containerItem)
        {
            _containerItem = containerItem;
            _itemViewModel = new ItemViewModel(_containerItem.Item);
        }
        private ItemViewModel _itemViewModel;
        public ItemViewModel ItemViewModel
        {
            get
            {
                return _itemViewModel;
            }
        }

        public int Quantity
        {
            get
            {
                return _containerItem.Quantity;
            }
            set
            {
                _containerItem.Quantity = value;
            }
        }
    }
}
