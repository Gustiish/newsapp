using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Presentation.Command
{
    public class RelayCommand<T> : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private readonly Action<T> _execute;
        private readonly Func<T, bool>? _canExecute;

        public RelayCommand(Action<T> execute, Func<T, bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }


        public bool CanExecute(object? parameter)
        {
            if (_canExecute == null)
                return true;
            if (parameter == null && typeof(T).IsValueType)
                return _canExecute(default!);
            if (parameter is T tParam)
                return _canExecute(tParam);
            return false;
        }

        public void Execute(object? parameter)
        {
            if (parameter == null && typeof(T).IsValueType)
                _execute(default!);

            else
                _execute((T)parameter!);
        }

        public void CanExecuteChangedInvoke()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;


        public event EventHandler? CanExecuteChanged;

        public RelayCommand(Action execute)
        {
            _execute = execute;
        }



        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter = null) => _execute.Invoke();

    }
}
