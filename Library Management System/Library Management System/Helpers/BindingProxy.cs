using Microsoft.UI.Xaml;

namespace Library_Management_System.Helpers;

public class BindingProxy : DependencyObject
{
    public static readonly DependencyProperty DataProperty = DependencyProperty.Register(
        nameof(Data),
        typeof(object),
        typeof(BindingProxy),
        new PropertyMetadata(null));

    public object Data
    {
        get { return GetValue(DataProperty); }
        set { SetValue(DataProperty, value); }
    }
}
