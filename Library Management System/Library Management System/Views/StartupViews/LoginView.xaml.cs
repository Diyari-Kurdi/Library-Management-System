using Microsoft.UI.Xaml.Controls;

namespace Library_Management_System.Views.StartupViews;

public sealed partial class LoginView : Page
{
    public LoginViewModel LoginViewModel { get; }
    public LoginView()
    {
        LoginViewModel = App.AppHost.Services.GetRequiredService<LoginViewModel>();
        this.InitializeComponent();
    }
}
