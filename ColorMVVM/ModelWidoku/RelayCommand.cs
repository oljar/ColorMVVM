﻿using System;
using System.Diagnostics;
using System.Windows.Input;

public class RelayCommand : ICommand
{
    #region Fields
    readonly Action<object> _execute;
    readonly Predicate<object> _canExecute;
    #endregion // Fields

    #region Constructors
    public RelayCommand(Action<object> execute)
        : this(execute, null)
    {
    }

    public RelayCommand(Action<object> execute, Predicate<object> canExecute)
    {
        if (execute == null) throw new ArgumentNullException("execute");
        _execute = execute;
        _canExecute = canExecute;
    }
    #endregion // Constructors

    #region ICommand Members
    [DebuggerStepThrough]
    public bool CanExecute(object parameter)
    {
        return _canExecute == null ? true : _canExecute(parameter);
    }

    public event EventHandler CanExecuteChanged;

    public void OnCanExecuteChanged()
    {
        if (CanExecuteChanged != null) CanExecuteChanged(this, EventArgs.Empty);
    }

    public void Execute(object parameter)
    {
        _execute(parameter);
    }
    #endregion // ICommand Members
}
