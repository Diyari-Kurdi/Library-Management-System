using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library_Management_System.ViewModels.MainViewModels;

public partial class AuthorsViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<AuthorModel> _authors = new();
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddNewAuthorCommand), nameof(UpdateCommand))]
    private AuthorModel? _selectedAuthor;
    public Page View { get; set; } = null!;
    public AuthorsViewModel()
    {
        _ = GetData();
    }

    private async Task GetData()
    {
        var authors = await MySqlService.SelectAuthorsAsync();
        if (authors != null)
            Authors = new(authors);
    }
    [RelayCommand]
    private async Task AddNewAuthor()
    {
        var ViewModel = App.AppHost.Services.GetRequiredService<AddAuthorViewModel>();
        ContentDialog dialog = new()
        {
            XamlRoot = View.XamlRoot,
            Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
            CloseButtonText = "Cancel",
            Title = "Add New Author",
            PrimaryButtonText = "Add",
            IsPrimaryButtonEnabled = true,
            PrimaryButtonCommandParameter = ViewModel.Result,
            CloseButtonCommand = ViewModel.ClearCommand,
            IsSecondaryButtonEnabled = true,
            DefaultButton = ContentDialogButton.Primary,
            Content = App.AppHost.Services.GetRequiredService<AddAuthorView>()
        };
        dialog.Closed += Dialog_Closed;
        await dialog.ShowAsync();
    }
    private async void Dialog_Closed(ContentDialog sender, ContentDialogClosedEventArgs args)
    {
        if (args.Result == ContentDialogResult.Primary)
        {
            if (sender.PrimaryButtonCommandParameter is AuthorModel newAuthor)
            {
                try
                {
                    if (await MySqlService.InsertAsync(newAuthor, InfoDeliveryService.CurrentInfoBar, CancellationToken.None) > 0)
                        Authors.Add(newAuthor);
                }
                catch { }
            }
        }
    }
    private bool CanEdit() => SelectedAuthor != null;

    [RelayCommand(CanExecute = nameof(CanEdit))]
    private async Task Delete()
    {
        if (SelectedAuthor != null)
        {
            var id = SelectedAuthor.ID;
            if (await MySqlService.DeleteAsync(new AuthorModel() { ID = id }, "ID", InfoDeliveryService.CurrentInfoBar, CancellationToken.None) > 0)
                Authors.Remove(Authors.Single(b => b.ID == id));
        }
    }

    [RelayCommand(CanExecute = nameof(CanEdit))]
    private async Task Update()
    {
        if (SelectedAuthor != null)
        {
            var id = SelectedAuthor.ID;
            try
            {
                var ViewModel = App.AppHost.Services.GetRequiredService<AddAuthorViewModel>();
                ViewModel.Author = SelectedAuthor;
                ContentDialog dialog = new()
                {
                    XamlRoot = View.XamlRoot,
                    Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
                    CloseButtonText = "Cancel",
                    Title = "Update " + SelectedAuthor.FullName,
                    PrimaryButtonText = "Update",
                    IsPrimaryButtonEnabled = true,
                    PrimaryButtonCommandParameter = ViewModel.Result,
                    CloseButtonCommand = ViewModel.ClearCommand,
                    IsSecondaryButtonEnabled = true,
                    ExitDisplayModeOnAccessKeyInvoked = false,
                    DefaultButton = ContentDialogButton.Primary,
                    Content = App.AppHost.Services.GetRequiredService<AddAuthorView>()
                };
                dialog.Closed += UpdateDialog_Closed;
                _recordToUpdate = id;
                await dialog.ShowAsync();
            }
            catch { }
        }
    }
    private int _recordToUpdate;
    private async void UpdateDialog_Closed(ContentDialog sender, ContentDialogClosedEventArgs args)
    {
        if (args.Result == ContentDialogResult.Primary)
        {
            if (sender.PrimaryButtonCommandParameter is AuthorModel newAuthor)
            {
                try
                {
                    if (await MySqlService.UpdateAsync(_recordToUpdate, newAuthor, InfoDeliveryService.CurrentInfoBar, CancellationToken.None) > 0)
                    {
                        Authors.Remove(Authors.First(b => b.ID == _recordToUpdate));
                        Authors.Add(newAuthor);
                    }
                }
                catch { await GetData(); }
            }
        }
        else { await GetData(); }
    }

}
