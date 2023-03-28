using Microsoft.UI.Xaml.Controls;

namespace Library_Management_System.Views.MainViews;

public sealed partial class AddBookView : Page
{
    public AddBookViewModel AddBookViewModel { get; }
    public AddBookView()
    {
        AddBookViewModel = App.AppHost.Services.GetRequiredService<AddBookViewModel>();
        this.InitializeComponent();
        Loaded += async (sender, e) =>
        {
            await AddBookViewModel.GetData();
        };
    }
}
