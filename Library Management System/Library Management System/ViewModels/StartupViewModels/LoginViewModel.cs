using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Library_Management_System.ViewModels;

public partial class LoginViewModel : ObservableObject,IRecipient<MessageRecord>
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
    private static ImageSource _profilePicture = new BitmapImage(new Uri("ms-appx:///Resources/Images/Avatar.png"));


    [RelayCommand]
    private async Task GetPictures()
    {
        if (await SQLiteService.SelectAsync<UserModel>(CancellationToken.None) is IEnumerable<UserModel> users && users is not null)
        {
            UserProfilePictures.Clear();
            foreach (UserModel user in users)
            {
                UserProfilePictures.Add(user.Username, user.Avatar);
            }
        }

    }

    public LoginViewModel()
    {
        _ = GetPictures();
        WeakReferenceMessenger.Default.Register(this);
    }

    private bool CanLogin() => !(string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password));

    [RelayCommand(CanExecute = nameof(CanLogin))]
    private async Task Login()
    {
        try
        {
            var result = await SQLiteService.Login(Table.users, Username, Password, InfoDeliveryService.CurrentInfoBar, CancellationToken.None);
            if (result)
            {
                Author.Username = Username;
                Author.ProfilePicture = ProfilePicture;
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

    [RelayCommand]
    private static void GoToRegister()
    {
        WeakReferenceMessenger.Default.Send(new MessageRecord(MessageResult.GoForward));
    }

    public async void Receive(MessageRecord message)
    {
        if (message.MessageResult == MessageResult.GoBack) 
            await GetPictures();
    }
}
