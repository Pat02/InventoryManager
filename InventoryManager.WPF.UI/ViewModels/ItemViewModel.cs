using InventoryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.WPF.UI.ViewModels
{
    class ItemViewModel : ViewModelBase
    {
        private Item _item;

        public ItemViewModel(Item item)
        {
            _item = item;
        }

        public string Name
        {
            get
            {
                return _item.Name;
            }
            set
            {
                if (_item.Name != value)
                {
                    _item.Name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public double Weight
        {
            get
            {
                return _item.Weight;
            }
            set
            {
                if (_item.Weight != value)
                {
                    _item.Weight = value;
                    OnPropertyChanged(nameof(Weight));
                }
            }
        }
    }


}
