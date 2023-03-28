
using Microsoft.UI.Xaml.Controls;

namespace Library_Management_System.Views.StartupViews;

public sealed partial class RegisterView : Page
{
    public RegisterViewModel RegisterViewModel { get; }
    public RegisterView()
    {
        RegisterViewModel = App.AppHost.Services.GetRequiredService<RegisterViewModel>();
        this.InitializeComponent();
    }
}
