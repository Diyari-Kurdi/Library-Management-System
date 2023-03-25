using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Threading;
using System.Threading.Tasks;

namespace Library_Management_System.ViewModels.SetupViewModels;

public partial class MySqlSetupViewModel : ObservableObject
{
    public Page View { get; set; } = null!;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(GoToAccountSetupViewCommand))]
    private string _host = "localhost";
    [ObservableProperty]
    private string? _port = "3306";
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(GoToAccountSetupViewCommand))]
    private string _projectName = string.Empty;
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(GoToAccountSetupViewCommand))]
    private string _databaseName = string.Empty;
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(GoToAccountSetupViewCommand))]
    private string _username = string.Empty;

    private bool CanGo() => !(string.IsNullOrEmpty(Host) ||
                              string.IsNullOrEmpty(ProjectName) ||
                              string.IsNullOrEmpty(DatabaseName) ||
                              string.IsNullOrEmpty(Username));

    private CancellationTokenSource CTS = null!;

    [RelayCommand(CanExecute = nameof(CanGo))]
    private async Task GoToAccountSetupView(PasswordBox passwordBox)
    {
        CTS = new();
        ContentDialog dialog = new()
        {
            XamlRoot = View.XamlRoot,
            Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
            CloseButtonText = "Cancel",
            Title = "Please wait.",
            IsPrimaryButtonEnabled = false,
            IsSecondaryButtonEnabled = false,
            DefaultButton = ContentDialogButton.Primary,
            Content = new ProgressRing()
        };
        dialog.Closed += Dialog_Closed;
        _ = dialog.ShowAsync();
        ServerModel server = new()
        {
            Host = Host,
            Port = int.Parse(Port!),
            RootUsername = Username,
            RootPassword = passwordBox,
            ProjectName = ProjectName,
            DatabaseName = DatabaseName,
        };
        bool result = await ServerSetupService.IsConnectionValid(server, InfoDeliveryService.CurrentInfoBar, CTS.Token);
        dialog.Hide();
        if (result)
        {
            TempData.ServerModel = server;
            WeakReferenceMessenger.Default.Send(new MessageRecord(MessageResult.Success));
        }
    }

    private void Dialog_Closed(ContentDialog sender, ContentDialogClosedEventArgs args)
    {
        if (args.Result == ContentDialogResult.None)
            if (!CTS.IsCancellationRequested)
                CTS.Cancel();
    }
}
