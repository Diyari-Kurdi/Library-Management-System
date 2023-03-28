using Microsoft.UI.Composition;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using System;
using System.Numerics;
using Windows.Foundation.Metadata;

namespace Library_Management_System.Views.MainViews
{
    public sealed partial class LibraryView : Page
    {
        public LibraryViewModel LibraryViewModel { get; }
        public LibraryView()
        {
            LibraryViewModel = App.AppHost.Services.GetRequiredService<LibraryViewModel>();
            this.InitializeComponent();
            _ = Player.PlayAsync(0, 1, true);
            this.NavigationCacheMode = Microsoft.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            LibraryViewModel.View = this;
        }

        private async void LibraryView_Loaded(object sender, RoutedEventArgs e)
        {
            if (LibraryViewModel.SelectedBook != null)
            {
                ContentGridView.ScrollIntoView(LibraryViewModel.SelectedBook, ScrollIntoViewAlignment.Default);
                ContentGridView.UpdateLayout();

                ConnectedAnimation animation = ConnectedAnimationService.GetForCurrentView().GetAnimation("BackConnectedAnimation");
                if (animation != null)
                {
                    if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 7))
                    {
                        animation.Configuration = new DirectConnectedAnimationConfiguration();
                    }

                    await ContentGridView.TryStartConnectedAnimationAsync(animation, LibraryViewModel.SelectedBook, "connectedElement");
                }

                ContentGridView.Focus(FocusState.Programmatic);
            }
        }

        private void ContentGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ContentGridView.ContainerFromItem(e.ClickedItem) is GridViewItem container)
            {
                LibraryViewModel.SelectedBook = (FullBookModel)container.Content;
                ContentGridView.PrepareConnectedAnimation("ForwardConnectedAnimation", LibraryViewModel.SelectedBook, "connectedElement");
            }
            Frame.Navigate(typeof(DetailedInfoPage), LibraryViewModel.SelectedBook, new SuppressNavigationTransitionInfo());

        }

        readonly Compositor _compositor = App.m_window.Compositor;
        SpringVector3NaturalMotionAnimation? _springAnimation;
        private void CreateOrUpdateSpringAnimation(float finalValue)
        {
            if (_springAnimation == null)
            {
                _springAnimation = _compositor.CreateSpringVector3Animation();
                _springAnimation.Target = "Scale";
            }

            _springAnimation.FinalValue = new Vector3(finalValue);
        }

        private void Element_PointerEntered(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            CreateOrUpdateSpringAnimation(1.1f);

            ((UIElement)sender).StartAnimation(_springAnimation);
        }

        private void Element_PointerExited(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            CreateOrUpdateSpringAnimation(1.0f);

            ((UIElement)sender).StartAnimation(_springAnimation);

        }
    }
}
