using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace InventoryManager.WPF.UI.Commands
{
    public class RemoveCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
