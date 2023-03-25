using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using System;

namespace Library_Management_System.Models.Database;

public partial class BookModel : ObservableObject , ITableModel
{
    [ObservableProperty] private int _iD;
    [ObservableProperty] private string _title = string.Empty;
    [ObservableProperty] private string _picture = string.Empty;
    [ObservableProperty] private string _summary = string.Empty;
    [ObservableProperty] private string _language = string.Empty;
    [ObservableProperty] private int _pages;
    [ObservableProperty] private string _author = string.Empty;
    [ObservableProperty] private DateTime? _publicationDate;
    [ObservableProperty] private string? _iSBN;
    [ObservableProperty] private string? _edition;
    [ObservableProperty] private string _genre = string.Empty;
    [ObservableProperty] private decimal _price;

    public string GetFormatedPublicationDate() => PublicationDate!.Value.Year.ToString();
    public ImageSource GetImageSource() => new BitmapImage(new(Picture));
    public Table GetTableName() => Table.books;
}
