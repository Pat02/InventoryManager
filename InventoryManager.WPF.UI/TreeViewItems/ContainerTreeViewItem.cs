using InventoryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Controls;
using Domain = InventoryManager.Domain.Models;

namespace InventoryManager.WPF.UI.TreeViewItems
{
    class ContainerTreeViewItem : BaseTreeViewItem
    {
        private Domain.Models.Container _container;

        public ContainerTreeViewItem(Domain.Models.Container container)
        {
            _container = container;
            _Inventory = new ObservableCollection<ContainerItem>();
        }

        

        private ObservableCollection<ContainerItem> _Inventory;
        public ObservableCollection<ContainerItem> Inventory
        {
            get
            {
                _Inventory.Clear();
                foreach (ContainerItem item in _container.Inventory)
                {
                    _Inventory.Add(item);
                }
                return _Inventory;
            }
            set
            {
                if (_Inventory != value)
                {
                    _container.Inventory.Clear();
                    foreach (ContainerItem containeritem in _Inventory)
                    {
                        _container.Inventory.Add(containeritem);
                    }
                    OnPropertyChanged(nameof(Inventory));
                }
            }
        }

        public double MaximumCarryCapacity
        {
            get
            {
                return _container.MaximumCarryWeight;
            }
            set
            {
                if (_container.MaximumCarryWeight != value)
                {
                    _container.MaximumCarryWeight = value;
                    OnPropertyChanged(nameof(MaximumCarryCapacity));
                }
            }
        }
        public double CurrentCarryCapacity
        {
            get
            {
                return _container.CurrentWeightInContainer;
            }
        }
        public bool IsRootContainer
        {
            get
            {
                return _container.IsRootContainer;
            }
            set
            {
                if (_container.IsRootContainer != value)
                {
                    _container.IsRootContainer = value;
                    OnPropertyChanged(nameof(IsRootContainer));
                }
            }
        }
    }
}
