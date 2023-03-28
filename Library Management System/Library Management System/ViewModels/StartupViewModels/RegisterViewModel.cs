using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Threading.Tasks;
using Windows.Storage.Pickers;

namespace Library_Management_System.ViewModels.StartupViewModels;

public partial class RegisterViewModel : ObservableObject
{

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CreateAccountCommand))]
    private string _username = string.Empty;
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CreateAccountCommand))]
    private string _password = string.Empty;
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CreateAccountCommand))]
    private string _confirmPassword = string.Empty;

    private string PPic { get; set; } = "ms-appx:///Resources/Images/Avatar.png";
    [ObservableProperty]
    private ImageSource _profilePicture = new BitmapImage(new System.Uri("ms-appx:///Resources/Images/Avatar.png"));

    private bool CanCreateAccount()
    {
        if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmPassword))
            return false;
        if (Password == ConfirmPassword)
            return true;
        return false;
    }

    [RelayCommand(CanExecute = nameof(CanCreateAccount))]
    private async Task CreateAccount()
    {
        UserModel userModel = new()
        {
            Username = Username,
            Password = Password,
            Avatar = PPic
        };

        var result = await SQLiteService.InsertAsync(userModel, InfoDeliveryService.CurrentInfoBar, System.Threading.CancellationToken.None);
        if (result > 0)
        {
            WeakReferenceMessenger.Default.Send(new MessageRecord(MessageResult.GoBack));
        }
    }

    [RelayCommand]
    private void GoBack()
    {
        WeakReferenceMessenger.Default.Send(new MessageRecord(MessageResult.GoBack));
    }

    [RelayCommand]
    private async Task PickAnImage()
    {
        var openPicker = new FileOpenPicker();

        var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(App.m_window);

        WinRT.Interop.InitializeWithWindow.Initialize(openPicker, hWnd);

        openPicker.ViewMode = PickerViewMode.Thumbnail;
        openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
        openPicker.FileTypeFilter.Add(".jpg");
        openPicker.FileTypeFilter.Add(".jpeg");
        openPicker.FileTypeFilter.Add(".png");

        var pickedFile = await openPicker.PickSingleFileAsync();
        if (pickedFile != null)
        {
            PPic = await pickedFile.AddFile();
            ProfilePicture = new BitmapImage(new Uri(PPic));
        }

    }
}
