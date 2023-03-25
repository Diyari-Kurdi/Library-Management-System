namespace Library_Management_System.Models;

public class ForeignKeyModel
{
    public required string ForeignKeyName { get; set; }
    public required Table? ForeignKeyFromTable { get; set; }
    public required string ForeignKeyFromColumn { get; set; }
    public required string ForeignKeyToColumn { get; set; }
}
