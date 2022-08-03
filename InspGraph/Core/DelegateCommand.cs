using System.Windows.Input;

public class DelegateCommand : ICommand
{
    public DelegateCommand(Action<object?> execute)
        : this(execute, null)
    {
    }

    public DelegateCommand(Action<object?> execute, Func<object?, bool>? canExecute)
    {
        this._execute = execute;
        this._canExecute = canExecute;
    }

    public event EventHandler? CanExecuteChanged;

    public void RaiseCanExecuteChanged() => this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);

    public bool CanExecute(object? parameter) => this._canExecute?.Invoke(parameter) ?? true;

    public void Execute(object? parameter) => this._execute.Invoke(parameter);

    private Action<object?> _execute;
    private Func<object?, bool>? _canExecute;
}