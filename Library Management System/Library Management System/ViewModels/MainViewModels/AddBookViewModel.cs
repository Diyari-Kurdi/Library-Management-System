using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Windows.Storage.Pickers;

namespace Library_Management_System.ViewModels.MainViewModels;

public partial class AddBookViewModel : ObservableObject
{
    [ObservableProperty]
    private FullBookModel _book = new();
    [ObservableProperty]
    private IEnumerable<AuthorModel>? _authors;
    [ObservableProperty]
    private AuthorModel? _selectedAuthor;
    [ObservableProperty]
    private CategoryModel? _selectedCategory;

    [ObservableProperty]
    private IEnumerable<CategoryModel>? _categories;

    public async Task GetData()
    {
        Authors = await MySqlService.SelectAsync<AuthorModel>(CancellationToken.None);
        Categories = await MySqlService.SelectAsync<CategoryModel>(CancellationToken.None);

        if (Authors != null)
            if (Authors.Any(a => a.ID == Book.AuthorID))
                SelectedAuthor = Authors.First(a => a.ID == Book.AuthorID);

        if (Categories != null)
            if (Categories.Any(g => g.ID == Book.GenreID))
                SelectedCategory = Categories.First(g => g.ID == Book.GenreID);
    }

    public FullBookModel Result => Book;
    [RelayCommand]
    private void Clear()
    {
        try
        {
            Book = new();
        }
        catch
        {

        }
    }

    [RelayCommand]
    private async Task ChooseImage()
    {
        var picker = new Windows.Storage.Pickers.FileOpenPicker();

        var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(App.m_window);

        WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);

        picker.ViewMode = PickerViewMode.Thumbnail;
        picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
        picker.FileTypeFilter.Add(".jpg");
        picker.FileTypeFilter.Add(".jpeg");
        picker.FileTypeFilter.Add(".png");

        var pickedFile = await picker.PickSingleFileAsync();
        if (pickedFile != null)
        {
            Book.Picture = pickedFile.Path.Replace(@"\", @"/");
        }
    }
}
