using System.ComponentModel;

public class SharedViewModel : INotifyPropertyChanged
{
    private int _count = 0;
    public int Count
    {
        get => _count;
        set
        {
            if (_count != value)
            {
                _count = value;
                OnPropertyChanged(nameof(Count));
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void UpCount()
    {
        ++Count;
    }

    public void DownCount()
    {
        --Count;
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}