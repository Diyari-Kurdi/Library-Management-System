namespace Library_Management_System.Models;

public class SettingsModel
{
    public string? ProfilePicture { get; set; }
    public bool IsFirstTime { get; set; } = true;
    public string DatabaseName { get; set; } = string.Empty;
    public string ConnectionString { get; set; } = string.Empty;
}
