namespace Library_Management_System.Models.Database;

public partial class CategoryModel : ObservableObject, ITableModel
{
    [ObservableProperty]
    private int _iD;
    [ObservableProperty]
    private string _genre = string.Empty;
    [ObservableProperty]
    private string _description = string.Empty;

    public Table GetTableName() => Table.categories;
}
