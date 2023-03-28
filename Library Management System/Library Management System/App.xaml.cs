using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;

namespace Library_Management_System;

public partial class App : Application
{
    public static IHost AppHost { get; private set; } = null!;
    public App()
    {
        AppHost = Host.CreateDefaultBuilder().ConfigureServices((contexts, services) =>
        {
            services.AddSingleton<SetupWindow>();
            services.AddSingleton<SetupViewModel>();

            services.AddSingleton<MySqlSetupView>();
            services.AddSingleton<MySqlSetupViewModel>();

            services.AddSingleton<AccountSetupView>();
            services.AddSingleton<AccountSetupViewModel>();

            services.AddSingleton<LoginWindow>();
            services.AddSingleton<LoginViewModel>();

            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainViewModel>();

            services.AddSingleton<LibraryView>();
            services.AddTransient<LibraryViewModel>();

            services.AddTransient<AddBookView>();
            services.AddSingleton<AddBookViewModel>();

            services.AddSingleton<AuthorsView>();
            services.AddTransient<AuthorsViewModel>();

            services.AddTransient<AddAuthorView>();
            services.AddSingleton<AddAuthorViewModel>();

            services.AddSingleton<CategoriesView>();
            services.AddTransient<CategoriesViewModel>();

            services.AddTransient<AddCategoryView>();
            services.AddSingleton<AddCategoryViewModel>();

            services.AddSingleton<IMessenger, WeakReferenceMessenger>();
        }).Build();
        this.InitializeComponent();
    }
    public static Window m_window = null!;
    protected override async void OnLaunched(LaunchActivatedEventArgs args)
    {
        var settings = await ApplicationSettings.LoadSettings();
        if (settings != null)
        {
            ApplicationSettings.Settings = settings;
        }
        if (ApplicationSettings.Settings.IsFirstTime)
            m_window = AppHost.Services.GetRequiredService<SetupWindow>();
        else
        {
#if DEBUG
            m_window = AppHost.Services.GetRequiredService<MainWindow>();
#else
            m_window = AppHost.Services.GetRequiredService<LoginWindow>();
#endif
        }

        m_window.Activate();
    }
}
