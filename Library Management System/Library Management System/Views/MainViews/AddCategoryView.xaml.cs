using Microsoft.UI.Xaml.Controls;

namespace Library_Management_System.Views.MainViews;

public sealed partial class AddCategoryView : Page
{
    public AddCategoryViewModel AddCategoryViewModel { get; }
    public AddCategoryView()
    {
        AddCategoryViewModel = App.AppHost.Services.GetRequiredService<AddCategoryViewModel>();
        this.InitializeComponent();
    }
}
