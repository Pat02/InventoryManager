using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Domain.Models
{
    public class Container : Item, IStorable
    {
        public string NickName { get; set; } = string.Empty;
        public double MaximumCarryWeight { get; set; }
        
        public List<IStorable> Inventory { get; set; }
        public bool IsRootContainer { get; set; } = false;

        public bool ContainerItemWeightCountsToContainerTotal(ContainerItem containerItem)
        {
            if (containerItem.ItemLocation == ItemLocation.inContainer) return true;
            else return false;
        }

        private double _CurrentWeightInContainer = 0;
        /// <summary>
        /// This is used to calculate if the Container is overburdened.
        /// It ignores items strapped to the outside, per the DM rules.
        /// </summary>
        public double GetWeightForContainer()
        {
            foreach (ContainerItem containerItem in Inventory)
            {
                if (ContainerItemWeightCountsToContainerTotal(containerItem))
                {
                    _CurrentWeightInContainer += containerItem.ItemWeightSubtotal;
                }
            }
            return _CurrentWeightInContainer + Weight;
        }

        private double _TotalWeightofContainerAndAllChildItems = 0;
        /// <summary>
        /// This is for the total load on the character, including items strapped to outside.
        /// </summary>
        public double GetWeightIncludingStrappedItems()
        {
            foreach (IStorable containerItem in Inventory)
            {
                _TotalWeightofContainerAndAllChildItems += containerItem.GetWeightIncludingStrappedItems();
            }
            return _TotalWeightofContainerAndAllChildItems + Weight;
        }
    }
}