using Microsoft.UI.Xaml.Controls;
using System;
using System.Threading.Tasks;

namespace Library_Management_System.Services;

public static class InfoDeliveryService
{
    public static InfoBar CurrentInfoBar { get; set; } = new();
    public static async void Show(this InfoBar infoBar, string Message, string Title = "",
        InfoBarSeverity Severity = InfoBarSeverity.Error, int Duration = 3_000)
    {
        infoBar.Severity = Severity;
        infoBar.Title = Title;
        infoBar.Message = Message;
        infoBar.IsOpen = true;
        await Task.Delay(Duration);
        infoBar.IsOpen = false;
    }
    public static async void Show(this InfoBar infoBar, Exception exception, string Title = "",
        InfoBarSeverity Severity = InfoBarSeverity.Error, int Duration = 3_000)
    {
        infoBar.Severity = Severity;
        infoBar.Title = Title;
        infoBar.Message = exception.Message;
        infoBar.IsOpen = true;
        await Task.Delay(Duration);
        infoBar.IsOpen = false;
    }
}
