using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WPF_InventoryManager.Commands
{

    /// Simple command used in MVVM to run actions from the UI.
    internal class RelayCommand : ICommand
    {

        /// Action that will run when the command is executed.

        private readonly Action<object?> _execute;

        /// Function that decides if the command can run.

        private readonly Predicate<object?>? _canExecute;


        /// Creates a command with an action and a condition.
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }


        /// Creates a command that can always run.

        public RelayCommand(Action<object> execute):this(execute, null){}


        /// Checks if the command can run.
        public bool CanExecute(object? parameter)
        {
           return _canExecute == null ? true : _canExecute(parameter);
        }

        /// Runs the command action.

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }

        /// Updates the UI when the command availability changes.

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }

            remove { CommandManager.RequerySuggested -= value; }


        }
    }
}
