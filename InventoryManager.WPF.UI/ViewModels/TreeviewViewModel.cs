using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using InventoryManager.Domain.Models;

namespace InventoryManager.WPF.UI.ViewModels
{
    class TreeviewViewModel : ViewModelBase
    {
        private InventoryManager.Domain.Models.Container _rootContainer;
        public InventoryManager.Domain.Models.Container RootContainer
        {
            get
            {
                return _rootContainer;
            }
            set
            {
                _rootContainer = value;
                OnPropertyChanged(nameof(RootContainer));
            }
        }
    }
}
