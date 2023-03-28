using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using System;

namespace Library_Management_System.Models.Database;

public partial class BookModel : ObservableObject, ITableModel
{
    [ObservableProperty] private int _iD;
    [ObservableProperty] private string _title = string.Empty;
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ImageSource))]
    private string? _picture;
    [ObservableProperty] private string _summary = string.Empty;
    [ObservableProperty] private string _language = string.Empty;
    [ObservableProperty] private int _pages = 1;
    [ObservableProperty] private int? _authorID = 0;
    [ObservableProperty] private int _publishYear = 2010;
    [ObservableProperty] private string? _edition;
    [ObservableProperty] private int? _genreID = 0;
    [ObservableProperty] private string _price = "0";

    public ImageSource? ImageSource
    {
        get
        {
            if (Picture != null)
                return new BitmapImage(new Uri(Picture));
            return null;
        }
        set
        {

        }
    }
    public Table GetTableName() => Table.books;
}
