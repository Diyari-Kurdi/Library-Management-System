using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using Windows.Storage.Pickers;

namespace Library_Management_System.ViewModels.MainViewModels;

public partial class AddAuthorViewModel : ObservableObject
{
    [ObservableProperty]
    private AuthorModel _author = new();

    public AuthorModel Result => Author;

    [RelayCommand]
    private void Clear()
    {
        try
        {
            Author = new();
        }
        catch
        {

        }
    }

    [RelayCommand]
    private async Task ChooseImage()
    {
        var picker = new FileOpenPicker();

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
            Author.Picture = await pickedFile.AddFile();
        }
    }
}
