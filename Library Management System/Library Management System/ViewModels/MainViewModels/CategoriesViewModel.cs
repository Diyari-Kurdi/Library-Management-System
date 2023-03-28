using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library_Management_System.ViewModels.MainViewModels;

public partial class CategoriesViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<CategoryModel> _categories = new();
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddNewCategoryCommand), nameof(UpdateCommand))]
    private CategoryModel? _selectedCategory;
    public Page View { get; set; } = null!;
    public CategoriesViewModel()
    {
        _ = GetData();
    }

    private async Task GetData()
    {
        var categories = await SQLiteService.SelectAsync<CategoryModel>(CancellationToken.None);
        if (categories != null)
            Categories = new(categories);
    }
    AddCategoryViewModel ViewModel { get; set; } = null!;
    [RelayCommand]
    private async Task AddNewCategory()
    {
        ViewModel = App.AppHost.Services.GetRequiredService<AddCategoryViewModel>();
        ContentDialog dialog = new()
        {
            XamlRoot = View.XamlRoot,
            Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
            CloseButtonText = "Cancel",
            Title = "Add New Category",
            PrimaryButtonText = "Add",
            IsPrimaryButtonEnabled = true,
            PrimaryButtonCommandParameter = ViewModel.Result,
            CloseButtonCommand = ViewModel.ClearCommand,
            IsSecondaryButtonEnabled = true,
            DefaultButton = ContentDialogButton.Primary,
            Content = App.AppHost.Services.GetRequiredService<AddCategoryView>()
        };
        dialog.Closed += Dialog_Closed;
        await dialog.ShowAsync();
    }
    private async void Dialog_Closed(ContentDialog sender, ContentDialogClosedEventArgs args)
    {
        if (args.Result == ContentDialogResult.Primary)
        {
            if (sender.PrimaryButtonCommandParameter is CategoryModel newCategory)
            {
                try
                {
                    if (await SQLiteService.InsertAsync(newCategory, InfoDeliveryService.CurrentInfoBar, CancellationToken.None) > 0)
                    {
                        Categories.Add(newCategory);
                        ViewModel.Category = new();
                    }
                }
                catch { }
            }
        }
    }
    private bool CanEdit() => SelectedCategory != null;

    [RelayCommand(CanExecute = nameof(CanEdit))]
    private async Task Delete()
    {
        if (SelectedCategory != null)
        {
            var id = SelectedCategory.ID;
            if (await SQLiteService.DeleteAsync(new CategoryModel() { ID = id }, "ID", InfoDeliveryService.CurrentInfoBar, CancellationToken.None) > 0)
                Categories.Remove(Categories.Single(b => b.ID == id));
        }
    }

    [RelayCommand(CanExecute = nameof(CanEdit))]
    private async Task Update()
    {
        if (SelectedCategory != null)
        {
            var id = SelectedCategory.ID;
            try
            {
                ViewModel = App.AppHost.Services.GetRequiredService<AddCategoryViewModel>();
                ViewModel.Category = SelectedCategory;
                ContentDialog dialog = new()
                {
                    XamlRoot = View.XamlRoot,
                    Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
                    CloseButtonText = "Cancel",
                    Title = "Update " + SelectedCategory.Genre,
                    PrimaryButtonText = "Update",
                    IsPrimaryButtonEnabled = true,
                    PrimaryButtonCommandParameter = ViewModel.Result,
                    CloseButtonCommand = ViewModel.ClearCommand,
                    IsSecondaryButtonEnabled = true,
                    ExitDisplayModeOnAccessKeyInvoked = false,
                    DefaultButton = ContentDialogButton.Primary,
                    Content = App.AppHost.Services.GetRequiredService<AddCategoryView>()
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
            if (sender.PrimaryButtonCommandParameter is CategoryModel newCategory)
            {
                try
                {
                    if (await SQLiteService.UpdateAsync(_recordToUpdate, newCategory, InfoDeliveryService.CurrentInfoBar, CancellationToken.None) > 0)
                    {
                        Categories.Remove(Categories.First(b => b.ID == _recordToUpdate));
                        Categories.Add(newCategory);
                        ViewModel.Category = new();
                    }
                }
                catch { await GetData(); }
            }
        }
        else { await GetData(); }
    }


}
