using Microsoft.UI.Xaml.Controls;

namespace Library_Management_System.Models;

public class ServerModel
{
    public string Host { get; set; } = "localhost";
    public int Port { get; set; } = 3306;
    public required string ProjectName { get; set; }
    public required string DatabaseName { get; set; }
    public string RootUsername { get; set; } = "root";
    public PasswordBox RootPassword { get; set; } = new();
    public string ConnectionString 
    {
        get => $"Server={Host};User ID={RootUsername};Password={RootPassword.Password};Port={Port};";
    }
    public string DbConnectionString
    {
        get => $"Server={Host};User ID={RootUsername};Port={Port};database={DatabaseName};Password={RootPassword.Password};";
    }
}
