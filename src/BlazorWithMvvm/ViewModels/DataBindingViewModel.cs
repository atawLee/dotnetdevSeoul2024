namespace BlazorWithMvvm.ViewModels;

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class DataBindingViewModel
{
    public string UserName { get; set; }
    public string Message { get; set; }
    public void ShowMessage()
    {
        Message = "Button clicked at " + DateTime.Now.ToString("T");
    }
}