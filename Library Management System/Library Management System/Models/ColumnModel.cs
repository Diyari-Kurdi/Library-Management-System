namespace Library_Management_System.Models;

public class ColumnModel
{
    public required string Name { get; set; }
    public string DataType { get; set; } = string.Empty;
    public string? Default { get; set; } = string.Empty;
    public bool IsNullable { get; set; } = true;
    public bool IsUnique { get; set; } = false;
    public bool IsPrimaryKey { get; set; } = false;
    public bool IsAutoIncrament { get; set; } = false;
    public bool HasForeignKey { get; set; } = false;
    public Table? ReferenceFromTable { get; set; }
    public string? ReferenceFromColumn { get; set; } = "ID";
}
