using InventoryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.WPF.UI.ViewModels
{
    public class ContainerItemViewModel : StorableBaseViewModel
    {
        public ContainerItem ContainerItem { get; }

        public ContainerItemViewModel(ContainerItem containerItem)
        {
            ContainerItem = containerItem;
            _itemViewModel = new ItemViewModel(ContainerItem.Item);
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
                return ContainerItem.Quantity;
            }
            set
            {
                ContainerItem.Quantity = value;
            }
        }
    }
}
