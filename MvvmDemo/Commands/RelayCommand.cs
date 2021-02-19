using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;
namespace MvvmDemo.Commands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action _doWork;
        public RelayCommand(Action work)
        {
            _doWork = work;
        }
        public bool CanExecute(object parameter)
        {
            return _doWork == null ? false : true;
        }

        public void Execute(object parameter)
        {
            _doWork();
        }
    }

}
