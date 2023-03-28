using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Library_Management_System.Models.Database;

public partial class AuthorModel : ObservableObject, ITableModel
{
    [ObservableProperty]
    private int _iD;
    [ObservableProperty]
    private string _fullName = string.Empty;
    [ObservableProperty]
    private string? _picture;
    [ObservableProperty]
    [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
    private DateTimeOffset _birthday = new(new(2000, 1, 1));
    [ObservableProperty]
    private string? _birthPlace;
    [ObservableProperty]
    private string? _description;
    [ObservableProperty]
    private ObservableCollection<FullBookModel> _books = new();

    public ObservableCollection<GroupInfoList> GetGroupedBooks
    {
        get
        {
            var query = from item in Books
                        group item by item.Title[..1].ToUpper() into g
                        orderby g.Key
                        select new GroupInfoList(g) { Key = g.Key };

            return new ObservableCollection<GroupInfoList>(query);
        }
    }
    public ImageSource? ImageSource
    {
        get
        {
            if (Picture != null)
                return new BitmapImage(new Uri(Picture));
            return null;
        }
        set { }
    }
    public Table GetTableName() => Table.authors;
}


public class GroupInfoList : List<object>
{
    public GroupInfoList(IEnumerable<object> items) : base(items)
    {
    }
    public object? Key { get; set; }

    public override string ToString()
    {
        return "Group " + Key?.ToString();
    }
}