using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Float.Command
{
    public class DelegateCommand : ICommand
    {
        public readonly Action action;

        public event EventHandler CanExecuteChanged;
        public DelegateCommand(Action action)
        {
            this.action = action;
        }

        public void Execute(object parameter)
        {
            action();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }

    public class DelegateCommand<T> : ICommand
    {
        public readonly Action<T> action;

        public event EventHandler CanExecuteChanged;
        public DelegateCommand(Action<T> action)
        {
            this.action = action;
        }

        public void Execute(object parameter)
        {
            action((T)parameter);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
