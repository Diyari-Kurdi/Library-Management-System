using Microsoft.UI.Xaml;
using WinRT;

namespace Library_Management_System.Views;

public sealed partial class LoginWindow : Window
{
    public LoginViewModel LoginViewModel { get; }
    public LoginWindow()
    {
        LoginViewModel = App.AppHost.Services.GetRequiredService<LoginViewModel>();
        this.InitializeComponent();
        ExtendsContentIntoTitleBar = true;
        Title = "Library Management System";
        SetTitleBar(AppTitleBar);
        TrySetAcrylicBackdrop();
        InfoDeliveryService.CurrentInfoBar = infoBar;
    }

    WindowsSystemDispatcherQueueHelper m_wsdqHelper = null!;
    Microsoft.UI.Composition.SystemBackdrops.DesktopAcrylicController? m_acrylicController;
    Microsoft.UI.Composition.SystemBackdrops.SystemBackdropConfiguration? m_configurationSource;

    public bool TrySetAcrylicBackdrop()
    {
        if (Microsoft.UI.Composition.SystemBackdrops.DesktopAcrylicController.IsSupported())
        {
            m_wsdqHelper = new WindowsSystemDispatcherQueueHelper();
            m_wsdqHelper.EnsureWindowsSystemDispatcherQueueController();

            m_configurationSource = new Microsoft.UI.Composition.SystemBackdrops.SystemBackdropConfiguration();
            this.Activated += Window_Activated;
            this.Closed += Window_Closed;
            ((FrameworkElement)this.Content).ActualThemeChanged += Window_ThemeChanged;

            m_configurationSource.IsInputActive = true;
            SetConfigurationSourceTheme();

            m_acrylicController = new Microsoft.UI.Composition.SystemBackdrops.DesktopAcrylicController();

            m_acrylicController.AddSystemBackdropTarget(this.As<Microsoft.UI.Composition.ICompositionSupportsSystemBackdrop>());
            m_acrylicController.SetSystemBackdropConfiguration(m_configurationSource);
            return true;
        }

        return false; // Acrylic is not supported on this system
    }

    private void Window_Activated(object sender, WindowActivatedEventArgs args)
    {
        if (m_configurationSource != null)
            m_configurationSource.IsInputActive = args.WindowActivationState != WindowActivationState.Deactivated;
    }

    private void Window_Closed(object sender, WindowEventArgs args)
    {
        if (m_acrylicController != null)
        {
            m_acrylicController.Dispose();
            m_acrylicController = null;
        }
        this.Activated -= Window_Activated;
        m_configurationSource = null;
    }

    private void Window_ThemeChanged(FrameworkElement sender, object args)
    {
        if (m_configurationSource != null)
        {
            SetConfigurationSourceTheme();
        }
    }

    private void SetConfigurationSourceTheme()
    {
        if (m_configurationSource != null)
            switch (((FrameworkElement)this.Content).ActualTheme)
            {
                case ElementTheme.Dark: m_configurationSource.Theme = Microsoft.UI.Composition.SystemBackdrops.SystemBackdropTheme.Dark; break;
                case ElementTheme.Light: m_configurationSource.Theme = Microsoft.UI.Composition.SystemBackdrops.SystemBackdropTheme.Light; break;
                case ElementTheme.Default: m_configurationSource.Theme = Microsoft.UI.Composition.SystemBackdrops.SystemBackdropTheme.Default; break;
            }
    }
}
