using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Currency_Object_Model_Midterm.ViewModels
{
    partial class ViewModelRepo
    {
        class ViewModelRepoCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            public delegate void ICommandOnExecute(object parameter);
            public delegate bool ICommandOnCanExecute(object parameter);

            private ICommandOnExecute _execute;
            private ICommandOnCanExecute _canExecute;

            public ViewModelRepoCommand(ICommandOnExecute executeMethod, ICommandOnCanExecute canExecuteMethod)
            {
                _execute = executeMethod;
                _canExecute = canExecuteMethod;
            }

            public bool CanExecute(object parameter)
            {
                return _canExecute.Invoke(parameter);
            }

            public void Execute(object parameter)
            {
                 _execute.Invoke(parameter);
            }
        }
    }
}
