using InventoryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace InventoryManager.WPF.UI.ViewModels
{
    public class ContainerViewModel : StorableBaseViewModel
    {
        private Container _container;

        public ContainerViewModel(Container container)
        {
            _container = container;
            _Inventory = new ObservableCollection<IStorableViewModel>();
        }

        public string Name
        {
            get
            {
                return _container.Name;
            }
            set
            {
                if (_container.Name != value)
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

        private ObservableCollection<IStorableViewModel> _Inventory;
        public ObservableCollection<IStorableViewModel> Inventory
        {
            get
            {
                _Inventory.Clear();
                foreach (IStorable StorableItem in _container.Inventory)
                {
                    if (StorableItem is ContainerItem)
                    {
                        ContainerItem containerItem = (ContainerItem)StorableItem;
                        var containerItemViewModel = new ContainerItemViewModel(
                                                     new ContainerItem(containerItem.Item, containerItem.Quantity));
                        _Inventory.Add(containerItemViewModel);
                    }
                    else if (StorableItem is Container)
                    {
                        Container container = (Container)StorableItem;
                        var containerViewModel = new ContainerViewModel(container);
                        _Inventory.Add(containerViewModel);
                    }
                }
                return _Inventory;
            }
            set
            {
                if (_Inventory != value)
                {
                    _container.Inventory.Clear();
                    foreach (IStorableViewModel StorableItemViewModel in _Inventory)
                    {
                        if (StorableItemViewModel is ContainerItemViewModel containerItemViewModel)
                        {
                            _container.Inventory.Add(new ContainerItem(containerItemViewModel.ItemViewModel.Item,
                                                                       containerItemViewModel.Quantity));
                        }
                        else if (StorableItemViewModel is ContainerViewModel)
                        {
                            _container.Inventory.Add(new Container());
                        }
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
                return _container.GetWeightForContainer();
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
