using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using System;
using Windows.Foundation.Metadata;

namespace Library_Management_System.Views.MainViews
{
    public sealed partial class LibraryView : Page
    {
        public LibraryViewModel BooksViewModel { get; }
        public LibraryView()
        {
            BooksViewModel = App.AppHost.Services.GetRequiredService<LibraryViewModel>();
            this.InitializeComponent();
            this.NavigationCacheMode=Microsoft.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private async void LibraryView_Loaded(object sender, RoutedEventArgs e)
        {
            if (BooksViewModel.SelectedBook != null)
            {
                ContentGridView.ScrollIntoView(BooksViewModel.SelectedBook, ScrollIntoViewAlignment.Default);
                ContentGridView.UpdateLayout();

                ConnectedAnimation animation = ConnectedAnimationService.GetForCurrentView().GetAnimation("BackConnectedAnimation");
                if (animation != null)
                {
                    if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 7))
                    {
                        animation.Configuration = new DirectConnectedAnimationConfiguration();
                    }

                    await ContentGridView.TryStartConnectedAnimationAsync(animation, BooksViewModel.SelectedBook, "connectedElement");
                }

                ContentGridView.Focus(FocusState.Programmatic);
            }
        }


        private void ContentGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ContentGridView.ContainerFromItem(e.ClickedItem) is GridViewItem container)
            {
                BooksViewModel.SelectedBook = (BookModel)container.Content;
                ContentGridView.PrepareConnectedAnimation("ForwardConnectedAnimation", BooksViewModel.SelectedBook, "connectedElement");

            }
            Frame.Navigate(typeof(DetailedInfoPage), BooksViewModel.SelectedBook, new SuppressNavigationTransitionInfo());

        }
    }
}
