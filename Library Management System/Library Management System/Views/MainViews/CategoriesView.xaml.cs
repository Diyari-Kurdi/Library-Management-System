using Microsoft.UI.Composition;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Numerics;

namespace Library_Management_System.Views.MainViews;

public sealed partial class CategoriesView : Page
{
    public CategoriesViewModel CategoriesViewModel { get; }
    public CategoriesView()
    {
        CategoriesViewModel = App.AppHost.Services.GetRequiredService<CategoriesViewModel>();
        this.InitializeComponent();
        CategoriesViewModel.View = this;
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
