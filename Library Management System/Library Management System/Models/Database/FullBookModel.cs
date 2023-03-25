using Microsoft.UI.Xaml.Media;

namespace Library_Management_System.Models.Database;

public partial class FullBookModel : BookModel
{
    [ObservableProperty]
    private ImageSource? _bookCover;
}
