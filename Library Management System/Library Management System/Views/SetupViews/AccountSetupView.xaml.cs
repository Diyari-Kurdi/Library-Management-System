using Microsoft.UI.Xaml.Controls;

namespace Library_Management_System.Views.SetupViews;

public sealed partial class AccountSetupView : Page
{
    public AccountSetupViewModel AccountSetupViewModel { get; }
    public AccountSetupView()
    {
        AccountSetupViewModel = App.AppHost.Services.GetRequiredService<AccountSetupViewModel>();
        AccountSetupViewModel.View = this;
        this.InitializeComponent();
    }
}
