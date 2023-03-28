namespace Library_Management_System.Models.Database;

public partial class FullBookModel : BookModel
{
    [ObservableProperty]
    private string _author = string.Empty;
    [ObservableProperty]
    private string _genre = string.Empty;
}
