using Microsoft.UI.Xaml.Controls;
using System;
using System.Threading.Tasks;

namespace Library_Management_System.Views.MainViews;

public sealed partial class DashboardView : Page
{
    public DashboardView()
    {
        this.InitializeComponent();
        _ = StartAnimation();
    }

    private async Task StartAnimation() 
    {
        await Player.PlayAsync(0, 1,false);
        _ = Player.PlayAsync(0.24, 1, true);
    }
}
