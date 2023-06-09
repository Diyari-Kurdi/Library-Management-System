using Microsoft.UI.Xaml.Controls;

namespace Library_Management_System.Views.MainViews;

public sealed partial class AddAuthorView : Page
{
    public AddAuthorViewModel AddAuthorViewModel { get; }
    public AddAuthorView()
    {
        AddAuthorViewModel = App.AppHost.Services.GetRequiredService<AddAuthorViewModel>();
        this.InitializeComponent();
        Calendar.MinDate = new System.DateTimeOffset(new(1400,1,1));
    }
}
