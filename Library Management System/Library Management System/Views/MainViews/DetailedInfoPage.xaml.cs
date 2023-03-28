using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;

namespace Library_Management_System.Views.MainViews;

public sealed partial class DetailedInfoPage : Page
{
    public FullBookModel? DetailedObject { get; set; }
    public DetailedInfoPage()
    {
        this.InitializeComponent();
        GoBackButton.Loaded += GoBackButton_Loaded;
    }

    private void GoBackButton_Loaded(object sender, RoutedEventArgs e)
    {
        GoBackButton.Focus(FocusState.Programmatic);
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

        DetailedObject = (FullBookModel)e.Parameter;
        ConnectedAnimation imageAnimation = ConnectedAnimationService.GetForCurrentView().GetAnimation("ForwardConnectedAnimation");
        imageAnimation?.TryStart(detailedImage, new UIElement[] { coordinatedPanel });
    }

    protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
    {
        base.OnNavigatingFrom(e);

        ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("BackConnectedAnimation", detailedImage);
    }

    private void BackButton_Click(object sender, RoutedEventArgs e)
    {
        Frame.GoBack();
    }
}
