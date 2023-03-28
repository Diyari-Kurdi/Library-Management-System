using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library_Management_System.ViewModels.MainViewModels;

public partial class LibraryViewModel : ObservableObject
{
    public Page View { get; set; } = null!;

    [ObservableProperty]
    private Visibility _anyBooks = Visibility.Collapsed;

    [ObservableProperty]
    private ObservableCollection<FullBookModel> _books = new();
    partial void OnBooksChanged(ObservableCollection<FullBookModel> value)
    {
        if (Books.Count < 1)
            AnyBooks = Visibility.Visible;
        else
            AnyBooks = Visibility.Collapsed;
    }
    private IEnumerable<AuthorModel>? Authors { get; set; }
    private IEnumerable<CategoryModel>? Categories { get; set; }
    [ObservableProperty]
    private FullBookModel? _selectedBook;

    public LibraryViewModel()
    {
        _ = GetData();
    }

    public async Task GetData()
    {
        var books = await MySqlService.SelectFullBooksAsync();
        Books = new(books);
        Authors = await MySqlService.SelectAsync<AuthorModel>(CancellationToken.None);
        Categories = await MySqlService.SelectAsync<CategoryModel>(CancellationToken.None);
        Books.CollectionChanged += (sender, e) =>
        {
            OnPropertyChanged(nameof(Books));
            if (Books.Count < 1)
                AnyBooks = Visibility.Visible;
            else
                AnyBooks = Visibility.Collapsed;
        };
    }

    [RelayCommand]
    private async Task AddNewBook()
    {
        var ViewModel = App.AppHost.Services.GetRequiredService<AddBookViewModel>();
        ContentDialog dialog = new()
        {
            XamlRoot = View.XamlRoot,
            Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
            CloseButtonText = "Cancel",
            Title = "Add New Book",
            PrimaryButtonText = "Add",
            IsPrimaryButtonEnabled = true,
            PrimaryButtonCommandParameter = ViewModel.Result,
            CloseButtonCommand = ViewModel.ClearCommand,
            IsSecondaryButtonEnabled = true,
            DefaultButton = ContentDialogButton.Primary,
            Content = App.AppHost.Services.GetRequiredService<AddBookView>()
        };
        dialog.Closed += Dialog_Closed;
        await dialog.ShowAsync();
    }

    private async void Dialog_Closed(ContentDialog sender, ContentDialogClosedEventArgs args)
    {
        if (args.Result == ContentDialogResult.Primary)
        {
            if (sender.PrimaryButtonCommandParameter is FullBookModel newBook)
            {
                try
                {
                    var author = Authors?.First(auth => auth.ID == newBook.AuthorID)?.FullName;
                    if (!string.IsNullOrEmpty(author))
                    {
                        newBook.Author = author;
                    }
                    var genre = Categories?.First(genre => genre.ID == newBook.GenreID)?.Genre;
                    if (!string.IsNullOrEmpty(genre))
                    {
                        newBook.Genre = genre;
                    }
                    var book = new BookModel();
                    var fullBookType = newBook.GetType();
                    var bookType = book.GetType();
                    foreach (var propertyInfo in fullBookType.GetProperties())
                    {
                        var propertyName = propertyInfo.Name;
                        var propertyValue = propertyInfo.GetValue(newBook);
                        var property = bookType.GetProperty(propertyName);
                        if (property != null && property.CanWrite)
                        {
                            property.SetValue(book, propertyValue);
                        }
                    }
                    if (await MySqlService.InsertAsync(book, InfoDeliveryService.CurrentInfoBar, CancellationToken.None) > 0)
                        Books.Add(newBook);
                }
                catch { }
            }
        }
    }

    [RelayCommand]
    private async Task Delete(int id)
    {
        if (await MySqlService.DeleteAsync(new BookModel() { ID = id }, "ID", InfoDeliveryService.CurrentInfoBar, CancellationToken.None) > 0)
            Books.Remove(Books.Single(b => b.ID == id));
    }

    [RelayCommand]
    private async Task Update(int id)
    {
        try
        {
            FullBookModel selectedBook = Books.First(b => b.ID == id);
           
            var ViewModel = App.AppHost.Services.GetRequiredService<AddBookViewModel>();
            ViewModel.Book = selectedBook;
            ContentDialog dialog = new()
            {
                XamlRoot = View.XamlRoot,
                Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
                CloseButtonText = "Cancel",
                Title = "Update " + selectedBook.Title,
                PrimaryButtonText = "Update",
                IsPrimaryButtonEnabled = true,
                PrimaryButtonCommandParameter = ViewModel.Result,
                CloseButtonCommand = ViewModel.ClearCommand,
                IsSecondaryButtonEnabled = true,
                ExitDisplayModeOnAccessKeyInvoked = false,
                DefaultButton = ContentDialogButton.Primary,
                Content = App.AppHost.Services.GetRequiredService<AddBookView>()
            };
            dialog.Closed += UpdateDialog_Closed;
            _recordToUpdate = id;
            await dialog.ShowAsync();
        }
        catch { }
    }
    private int _recordToUpdate;
    private async void UpdateDialog_Closed(ContentDialog sender, ContentDialogClosedEventArgs args)
    {
        if (args.Result == ContentDialogResult.Primary)
        {
            if (sender.PrimaryButtonCommandParameter is FullBookModel newBook)
            {
                try
                {
                    var author = Authors?.First(auth => auth.ID == newBook.AuthorID)?.FullName;
                    if (!string.IsNullOrEmpty(author))
                    {
                        newBook.Author = author;
                    }
                    var genre = Categories?.First(genre => genre.ID == newBook.GenreID)?.Genre;
                    if (!string.IsNullOrEmpty(genre))
                    {
                        newBook.Genre = genre;
                    }
                    var book = new BookModel();
                    var fullBookType = newBook.GetType();
                    var bookType = book.GetType();
                    foreach (var propertyInfo in fullBookType.GetProperties())
                    {
                        var propertyName = propertyInfo.Name;
                        var propertyValue = propertyInfo.GetValue(newBook);
                        var property = bookType.GetProperty(propertyName);
                        if (property != null && property.CanWrite)
                        {
                            property.SetValue(book, propertyValue);
                        }
                    }
                    if (await MySqlService.UpdateAsync(_recordToUpdate, book, InfoDeliveryService.CurrentInfoBar, CancellationToken.None) > 0)
                    {
                        Books.Remove(Books.First(b => b.ID == _recordToUpdate));
                        Books.Add(newBook);
                    }
                }
                catch { }
            }
        }
    }
}
