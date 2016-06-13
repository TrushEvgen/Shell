using System;
using System.Windows.Input;

namespace Shell.Core
{
    public class RelayCommand : ICommand
    {
        #region Fields

        readonly Action execute = null;
        readonly Action<object> executeWithParam = null;
        readonly Predicate<object> canExecute = null;

        #endregion

        #region Constructors

        public RelayCommand(Action execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            this.execute = execute;
            this.canExecute = canExecute;
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            this.executeWithParam = execute;
            this.canExecute = canExecute;
        }

        #endregion

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            if (execute != null)
            {
                execute();
            }
            else if (executeWithParam != null)
            {
                executeWithParam(parameter);
            }
        }

        #endregion
    }
}
