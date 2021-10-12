using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace InventoryManager.WPF.UI.Commands
{
    public class AddContainerCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is TreeViewItems.BaseTreeViewItem)
            {
                int x = 0;
                x++;
            }
        }
    }
}
