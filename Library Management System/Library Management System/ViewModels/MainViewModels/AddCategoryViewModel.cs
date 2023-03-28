using CommunityToolkit.Mvvm.Input;

namespace Library_Management_System.ViewModels.MainViewModels;

public partial class AddCategoryViewModel : ObservableObject
{
    [ObservableProperty]
    private CategoryModel _category = new();

    public CategoryModel Result => Category;

    [RelayCommand]
    private void Clear()
    {
        try
        {
            Category = new();
        }
        catch
        {
        }
    }
}
