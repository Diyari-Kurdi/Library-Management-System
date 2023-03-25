using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Library_Management_System.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    private readonly Dictionary<string, string> UserProfilePictures = new();
    private readonly ImageSource DefaultPicture = _profilePicture;
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    private string _username = string.Empty;
    partial void OnUsernameChanged(string value)
    {
        try
        {
            var avatar = UserProfilePictures[value];
            ProfilePicture = new BitmapImage(new(avatar));
        }
        catch (KeyNotFoundException) { ProfilePicture = DefaultPicture; }
    }

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    private string _password = string.Empty;
    [ObservableProperty]
    private static ImageSource _profilePicture = new BitmapImage(new Uri("ms-appx:///Resources/unknownperson.png"));


    [RelayCommand]
    private async Task GetPictures()
    {
        if (await MySqlService.SelectAsync<UserModel>(CancellationToken.None) is IEnumerable<UserModel> users && users is not null)
        {
            foreach (UserModel user in users)
            {
                UserProfilePictures.Add(user.Username, user.Avatar);
            }
        }

    }

    public LoginViewModel()
    {
        _ = GetPictures();
    }

    private bool CanLogin() => !(string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password));

    [RelayCommand(CanExecute = nameof(CanLogin))]
    private async Task Login()
    {
        try
        {
            var result = await MySqlService.SelectAsync<UserModel>(
                new CommandOperationModel[]
                {
                new CommandOperationModel()
                {
                    Column = "Username",
                    Value = Username,
                },
                new CommandOperationModel()
                {
                    Column = "Password",
                    Value = Password,
                    LogicalOperator = LogicalOperators.None
                }

                });
            if (result != null)
            {
                Author.Username = Username;
                Author.ProfilePicture = ProfilePicture;
                result = null;
                Window Desktop = App.AppHost.Services.GetRequiredService<MainWindow>();
                Desktop.Activate();
                App.m_window.Close();
                App.m_window = Desktop;
            }
            else
            {
                InfoDeliveryService.CurrentInfoBar.Show("Inccorrect Password.");
            }
        }
        catch (InvalidOperationException)
        {
            InfoDeliveryService.CurrentInfoBar.Show($"Inccorrect Password.");
        }
        catch (Exception ex)
        {
            InfoDeliveryService.CurrentInfoBar.Show(ex.Message);
        }
    }
}
