using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
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

    private string _pPic { get; set; } = "ms-appx:///Resources/Images/Avatar.png";
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
                        DataType = SqlDataTypeConverter.GetDataType(SqlDataType.NVARCHAR,45),
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
            new()
            {
                Name = nameof(Table.categories),
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
                        Name = "Genre",
                        DataType = SqlDataTypeConverter.GetDataType(SqlDataType.NVARCHAR,45),
                        IsNullable = false,
                        IsUnique = true
                    },
                    new()
                    {
                        Name = "Description",
                        DataType = SqlDataTypeConverter.GetDataType(SqlDataType.TEXT),
                        IsNullable = true,
                    }
                },
            },
            new()
            {
                Name = nameof(Table.authors),
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
                        Name = "FullName",
                        DataType = SqlDataTypeConverter.GetDataType(SqlDataType.NVARCHAR,45),
                        IsNullable = false
                    },
                    new()
                    {
                        Name = "Picture",
                        DataType = SqlDataTypeConverter.GetDataType(SqlDataType.TEXT),
                    },
                    new()
                    {
                        Name = "Birthday",
                        DataType = SqlDataTypeConverter.GetDataType(SqlDataType.DATETIME),
                    },
                    new()
                    {
                        Name = "BirthPlace",
                        DataType = SqlDataTypeConverter.GetDataType(SqlDataType.VARCHAR,45),
                    },
                    new()
                    {
                        Name = "Description",
                        DataType = SqlDataTypeConverter.GetDataType(SqlDataType.TEXT),
                    },
                },
            },
            new()
            {
                Name = nameof(Table.books),
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
                        Name = "Title",
                        DataType = SqlDataTypeConverter.GetDataType(SqlDataType.TEXT),
                        IsNullable = false
                    },
                    new()
                    {
                        Name = "Picture",
                        DataType = SqlDataTypeConverter.GetDataType(SqlDataType.TEXT),
                    },
                    new()
                    {
                        Name = "Summary",
                        DataType = SqlDataTypeConverter.GetDataType(SqlDataType.TEXT),
                    },
                    new()
                    {
                        Name = "Language",
                        DataType = SqlDataTypeConverter.GetDataType(SqlDataType.VARCHAR,18),
                    },
                    new()
                    {
                        Name = "Pages",
                        DataType = SqlDataTypeConverter.GetDataType(SqlDataType.INT),
                    },
                    new()
                    {
                        Name = "AuthorID",
                        DataType = SqlDataTypeConverter.GetDataType(SqlDataType.INT),
                        IsNullable = false,
                        HasForeignKey = true,
                        ReferenceFromTable = Table.authors,
                        ReferenceFromColumn = "ID"
                    },
                    new()
                    {
                        Name = "PublishYear",
                        DataType = SqlDataTypeConverter.GetDataType(SqlDataType.INT),
                    },
                    new()
                    {
                        Name = "Edition",
                        DataType = SqlDataTypeConverter.GetDataType(SqlDataType.VARCHAR,45),
                    },
                    new()
                    {
                        Name = "GenreID",
                        DataType = SqlDataTypeConverter.GetDataType(SqlDataType.INT),
                        IsNullable = false,
                        HasForeignKey = true,
                        ReferenceFromTable = Table.categories,
                        ReferenceFromColumn = "ID"
                    },
                    new()
                    {
                        Name = "Price",
                        DataType = SqlDataTypeConverter.GetDataType(SqlDataType.DECIMAL,"10,0"),
                    },
                },
            }
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
