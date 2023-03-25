using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Library_Management_System.Configuration;
using Library_Management_System.Records;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Threading.Tasks;
using Windows.Storage.Pickers;

namespace Library_Management_System.ViewModels.SetupViewModels;

public partial class AccountSetupViewModel : ObservableObject
{
    public Page View { get; set; } = null!;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CreateAccountCommand))]
    private string _username = string.Empty;
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CreateAccountCommand))]
    private string _password = string.Empty;
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CreateAccountCommand))]
    private string _confirmPassword = string.Empty;

    private string _pPic { get; set; } = "https://free4kwallpapers.com/uploads/originals/2019/05/08/beautiful-landscape-wallpaper.jpg";
    [ObservableProperty]
    private ImageSource _profilePicture = new BitmapImage(new System.Uri("https://free4kwallpapers.com/uploads/originals/2019/05/08/beautiful-landscape-wallpaper.jpg"));

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
            ID = 1,
            Username = Username,
            Password = Password,
            Avatar = _pPic
        };
        TableModel[] tables = new TableModel[]
        {
            new()
            {
                Name = nameof(Table.users),
                Columns = new ColumnModel[]
                {
                    new()
                    {
                        Name = "ID",
                        DataType = SqlDataTypeConverter.GetDataType(SqlDataType.INT),
                        IsAutoIncrament= true,
                        IsNullable = false,
                        IsPrimaryKey = true
                    },
                    new()
                    {
                        Name = "Username",
                        DataType = SqlDataTypeConverter.GetDataType(SqlDataType.NVARCHAR,14),
                        IsNullable = false,
                        IsUnique = true
                    },
                    new()
                    {
                        Name = "Password",
                        DataType = SqlDataTypeConverter.GetDataType(SqlDataType.NVARCHAR,255),
                        IsNullable = false,
                    },
                    new()
                    {
                        Name = "Avatar",
                        DataType = SqlDataTypeConverter.GetDataType(SqlDataType.TEXT),
                        IsNullable = false
                    }
                },
            },
        };
        var result = await ServerSetupService.SetupServerAsync(tables, userModel, InfoDeliveryService.CurrentInfoBar);
        if (result) 
        {
            ApplicationSettings.Settings.DatabaseName = TempData.ServerModel!.DatabaseName;
            ApplicationSettings.Settings.ConnectionString = TempData.ServerModel.ConnectionString;
            ApplicationSettings.Settings.IsFirstTime = false;
            await ApplicationSettings.SaveSettings();
            Window window = App.AppHost.Services.GetRequiredService<LoginWindow>();
            window.Activate();
            App.m_window.Close();
            App.m_window = window;
        }
    }

    [RelayCommand]
    private static void GoBack() 
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
            _pPic = pickedFile.Path;
            ProfilePicture = new BitmapImage(new Uri(pickedFile.Path));
        }

    }
}
