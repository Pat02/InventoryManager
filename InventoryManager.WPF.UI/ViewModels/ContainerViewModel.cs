using InventoryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace InventoryManager.WPF.UI.ViewModels
{
    public class ContainerViewModel : ViewModelBase
    {
        private Container _container;

        public ContainerViewModel(Container container)
        {
            _container = container;
            _Inventory = new ObservableCollection<ContainerItemViewModel>();
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

        private ObservableCollection<ContainerItemViewModel> _Inventory;
        public ObservableCollection<ContainerItemViewModel> Inventory
        {
            get
            {
                _Inventory.Clear();
                foreach (ContainerItem item in _container.Inventory)
                {
                    _Inventory.Add(new ContainerItemViewModel(item));
                }
                return _Inventory;
            }
            set
            {
                if (_Inventory != value)
                {
                    _container.Inventory.Clear();
                    foreach(ContainerItemViewModel containerItemViewModel in _Inventory)
                    {
                        _container.Inventory.Add(new ContainerItem(containerItemViewModel.ItemViewModel.Item,
                                                                   containerItemViewModel.Quantity));
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
