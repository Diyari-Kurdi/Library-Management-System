using Microsoft.UI.Xaml.Controls;

namespace Library_Management_System.ViewModels;

public partial class SetupViewModel : ObservableObject
{
    [ObservableProperty]
    private Page _currentContent = App.AppHost.Services.GetRequiredService<MySqlSetupView>();
}
