using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ATM_APP
{
    public class DelegateCommand : ICommand
    {
        public DelegateCommand(Action _action)
        {
            action = _action;
        }

        private readonly Action action;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            action();
        }
    }
}
