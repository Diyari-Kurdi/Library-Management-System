namespace Library_Management_System.Models;

public class DatabaseModel
{
    public required string Name { get; set; }
    public required TableModel[] Tables { get; set; }
}
