using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Presentation.Command
{
    public class RelayCommandAsync : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private readonly Func<Task> _execute;
        private bool _isExecuting;

        public RelayCommandAsync(Func<Task> execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object? parameter) => !_isExecuting;


        public async void Execute(object? parameter)
        {
            if (_isExecuting)
                return;

            _isExecuting = true;
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);

            try
            {
                await _execute();
            }
            finally
            {
                _isExecuting = false;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
    public class RelayCommandAsync<T> : ICommand
    {
        private readonly Func<T, Task> _execute;
        private readonly Func<T, bool>? _canExecute;
        private bool _isExecuting;

        public event EventHandler? CanExecuteChanged;

        public RelayCommandAsync(Func<T, Task> execute, Func<T, bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            if (_isExecuting) return false;
            if (_canExecute == null) return true;

            if (parameter == null && typeof(T).IsValueType)
                return _canExecute(default!);

            return _canExecute((T)parameter!);
        }

        public async void Execute(object? parameter)
        {
            if (_isExecuting) return;

            _isExecuting = true;
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);

            try
            {
                if (parameter == null && typeof(T).IsValueType)
                    await _execute(default!);
                else
                    await _execute((T)parameter!);
            }
            finally
            {
                _isExecuting = false;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
