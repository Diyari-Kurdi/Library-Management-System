using Microsoft.UI.Xaml.Controls;

namespace Library_Management_System.Views.SetupViews;

public sealed partial class MySqlSetupView : Page
{
    public MySqlSetupViewModel MySqlSetupViewModel { get; }
    public MySqlSetupView()
    {
        MySqlSetupViewModel = App.AppHost.Services.GetRequiredService<MySqlSetupViewModel>();
        MySqlSetupViewModel.View = this;
        this.InitializeComponent();
    }
}
