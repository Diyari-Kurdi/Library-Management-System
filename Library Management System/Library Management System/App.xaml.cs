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
            services.AddSingleton<StartupWindow>();

            services.AddTransient<RegisterView>();
            services.AddSingleton<RegisterViewModel>();

            services.AddTransient<LoginView>();
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
    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
#if !DEBUG
        m_window = AppHost.Services.GetRequiredService<MainWindow>();
#else
        m_window = AppHost.Services.GetRequiredService<StartupWindow>();
#endif


        m_window.Activate();
    }
}
