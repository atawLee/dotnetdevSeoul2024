using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfMvvmSample;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private string _message = "Hello, WPF!";

    [RelayCommand]
    private void UpdateMessage()
    {
        Message = "Button Clicked!";
    }
}
