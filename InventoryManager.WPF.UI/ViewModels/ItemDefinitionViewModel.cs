using InventoryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.WPF.UI.ViewModels
{
    public class ItemDefinitionViewModel : BaseViewModel
    {
        public ItemDefinitionViewModel(ItemDefinition itemDefinition)
        {
            ItemDefinition = itemDefinition;
        }

        public ItemDefinition ItemDefinition { get; set; }

        public string Name
        {
            get
            {
                return ItemDefinition.Name;
            }
            set
            {
                if (ItemDefinition.Name != value)
                {
                    ItemDefinition.Name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public double Weight
        {
            get
            {
                return ItemDefinition.Weight;
            }
            set
            {
                if (ItemDefinition.Weight != value)
                {
                    ItemDefinition.Weight = value;
                    OnPropertyChanged(nameof(Weight));
                }
            }
        }
    }
}