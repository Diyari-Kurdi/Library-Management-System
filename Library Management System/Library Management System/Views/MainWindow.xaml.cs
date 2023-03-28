using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Linq;

namespace Library_Management_System.Views
{
    public sealed partial class MainWindow : Window
    {
        public MainViewModel MainViewModel { get; }
        public MainWindow()
        {
            MainViewModel = App.AppHost.Services.GetRequiredService<MainViewModel>();
            this.InitializeComponent();
            ExtendsContentIntoTitleBar = true;
            Title = "Library Management System";
            SetTitleBar(AppTitleBar);
            NavigationView.SelectedItem = NavigationView.MenuItems.First();
        }

        private void NavigationView_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItem is NavigationViewItem item)
            {
                if (item.Tag is string tag)
                    switch (tag)
                    {
                        case "Home":
                            NavigationView.Header = "Home";
                            ContentFrame.Navigate(typeof(DashboardView));
                            break;
                        case "Library":
                            NavigationView.Header = "Library";
                            ContentFrame.Navigate(typeof(LibraryView));
                            break;
                        case "Authors":
                            NavigationView.Header = "Authors";
                            ContentFrame.Navigate(typeof(AuthorsView));
                            break;
                        case "Categories":
                            NavigationView.Header = "Categories";
                            ContentFrame.Navigate(typeof(CategoriesView));
                            break;
                        default:
                            break;
                    }
            }
        }
    }
}
