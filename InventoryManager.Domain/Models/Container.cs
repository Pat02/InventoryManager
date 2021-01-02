using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Domain.Models
{
    public class Container : StorableItem, IStorable
    {
        public ItemDefinition ItemDefinition { get; }
        public string NickName { get; set; } = string.Empty;
        public double MaximumCarryWeight { get; set; }

        public List<StorableItem> Inventory { get; set; }
        public bool IsRootContainer { get; set; } = false;

        public Container()
        {
            ItemDefinition = new ItemDefinition();
        }

        public Container(ItemDefinition itemDefinition)
        {
            ItemDefinition = itemDefinition;
        }

        private double _CurrentWeightInContainer = 0;
        /// <summary>
        /// This is used to calculate if the Container is overburdened.
        /// It ignores items strapped to the outside, per the DM rules.
        /// </summary>
        public double GetWeightForContainer()
        {
            foreach (IStorable storable in Inventory)
            {
                if (storable is ContainerItem containerItem)
                {
                    if (ContainerItemWeightCountsToContainerTotal(containerItem))
                    {
                        _CurrentWeightInContainer += storable.GetWeightForContainer();
                    }
                }
                if (storable is Container container)
                {
                    _CurrentWeightInContainer += container.GetWeightForContainer();
                }
            }
            return _CurrentWeightInContainer + ItemDefinition.Weight;
        }

        private double _TotalWeightofContainerAndAllChildItems = 0;

        /// <summary>
        /// This is for the total load on the character, including items strapped to outside.
        /// </summary>
        public double GetWeightIncludingStrappedItems()
        {
            foreach (IStorable storable in Inventory)
            {
                if (storable is ContainerItem containerItem)
                {
                    _TotalWeightofContainerAndAllChildItems += containerItem.GetWeightForContainer();
                }
                if (storable is Container container)
                {
                    _TotalWeightofContainerAndAllChildItems += container.GetWeightForContainer();
                }
            }
            return _TotalWeightofContainerAndAllChildItems + ItemDefinition.Weight;
        }
    }
}