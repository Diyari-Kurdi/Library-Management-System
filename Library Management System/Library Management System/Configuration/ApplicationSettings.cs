using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace Library_Management_System.Configuration;

public static class ApplicationSettings
{
    public static SettingsModel Settings { get; set; } = new();

    private static readonly string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "Configuration.json");
    public static async Task SaveSettings()
    {
        using FileStream fileStream = new(path, FileMode.Create);
        await JsonSerializer.SerializeAsync(fileStream, Settings, new JsonSerializerOptions
        {
            IgnoreReadOnlyProperties = true,
            WriteIndented = true,
        });
        await LoadSettings();
    }
    public static async Task<SettingsModel?> LoadSettings()
    {
        try
        {
            using FileStream fileStream = new(path, FileMode.Open);
            return (await JsonSerializer.DeserializeAsync<SettingsModel>(fileStream));
        }
        catch
        {
            return null;
        }
    }
}
