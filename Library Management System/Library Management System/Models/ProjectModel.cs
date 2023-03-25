using System;

namespace Library_Management_System.Models;

[Serializable]
public class ProjectModel
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required DateTime CreatedDate { get; set; }
    public string Version { get; set; } = "1.0";
    public string Author { get; set; } = Environment.UserName;
    public required string DatabaseName { get; set; }
    public TableModel[]? Tables { get; set; }
}
