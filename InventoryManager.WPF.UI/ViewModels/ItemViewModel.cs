using InventoryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.WPF.UI.ViewModels
{
    public class ItemViewModel : ViewModelBase
    {
        

        public ItemViewModel(Item item)
        {
            Item = item;
        }

        public Item Item { get; set; }

        public string Name
        {
            get
            {
                return Item.Name;
            }
            set
            {
                if (Item.Name != value)
                {
                    Item.Name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public double Weight
        {
            get
            {
                return Item.Weight;
            }
            set
            {
                if (Item.Weight != value)
                {
                    Item.Weight = value;
                    OnPropertyChanged(nameof(Weight));
                }
            }
        }
    }


}
