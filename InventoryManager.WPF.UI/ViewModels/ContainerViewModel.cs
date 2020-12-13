using InventoryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.WPF.UI.ViewModels
{
    public class ContainerViewModel : ViewModelBase
    {
        private Container _container;

        public ContainerViewModel(Container container)
        {
            _container = container;
        }

        public string Name
        {
            get
            {
                return _container.Name;
            }
            set
            {
                if(_container.Name != value)
                {
                    _container.Name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string NickName
        {
            get
            {
                return _container.NickName;
            }
            set
            {
                if (_container.NickName != value)
                {
                    _container.NickName = value;
                    OnPropertyChanged(nameof(NickName));
                }
            }
        }

        public double Weight
        {
            get
            {
                return _container.Weight;
            }
            set
            {
                if (_container.Weight != value)
                {
                    _container.Weight = value;
                    OnPropertyChanged(nameof(Weight));
                }
            }
        }

        public List<ContainerItem> Inventory
        {
            get
            {
                return _container.Inventory;
            }
            set
            {
                if (_container.Inventory != value)
                {
                    _container.Inventory = value;
                    OnPropertyChanged(nameof(Inventory));
                }
            }
        }

        public double MaximumCarryCapacity
        {
            get
            {
                return _container.MaximumCarryCapacity;
            }
            set
            {
                if (_container.MaximumCarryCapacity != value)
                {
                    _container.MaximumCarryCapacity = value;
                    OnPropertyChanged(nameof(MaximumCarryCapacity));
                }
            }
        }
        public double CurrentCarryCapacity
        {
            get
            {
                return _container.CurrentCarryCapacity;
            }
            set
            {
                if (_container.CurrentCarryCapacity != value)
                {
                    _container.CurrentCarryCapacity = value;
                    OnPropertyChanged(nameof(CurrentCarryCapacity));
                }
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
