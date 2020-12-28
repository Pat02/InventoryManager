using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Domain.Models
{
    public class Container : Item
    {
        public string NickName { get; set; }
        public double MaximumCarryWeight { get; set; }
        private double _CurrentWeightInContainer = 0;

        /// <summary>
        /// This is used to calculate if the Container is overburdened.
        /// It ignores items strapped to the outside, per the DM rules.
        /// </summary>
        public double CurrentWeightInContainer
        {
            get
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
        }
        private double _TotalWeightofContainerAndAllChildItems = 0;

        /// <summary>
        /// This is for the total load on the character, including items strapped to outside.
        /// </summary>
        public double TotalWeightofContainerAndAllChildItems
        {
            get
            {
                foreach (ContainerItem containerItem in Inventory)
                {
                    _TotalWeightofContainerAndAllChildItems += containerItem.ItemWeightSubtotal;
                }
                return _TotalWeightofContainerAndAllChildItems + Weight;
            }
        }
        public List<ContainerItem> Inventory { get; set; }
        public bool IsRootContainer { get; set; } = false;

        public bool ContainerItemWeightCountsToContainerTotal(ContainerItem containerItem)
        {
            if (containerItem.ItemLocation == ItemLocation.inContainer) return true;
            else return false;
        }

    }
}
