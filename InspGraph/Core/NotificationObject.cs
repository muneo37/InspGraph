using System.ComponentModel;
using System.Runtime.CompilerServices;

public class NotificationObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void RaisePropertyChanged([CallerMemberName]string? propertyName = null) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    protected bool SetProperty<T>(ref T target, T value, [CallerMemberName]string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(target, value))
            return false;
        target = value;
        RaisePropertyChanged(propertyName);
        return true;
    }
}