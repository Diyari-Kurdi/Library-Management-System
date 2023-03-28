namespace Library_Management_System.Models;

public class UserModel : ITableModel
{
    public int? ID { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Avatar { get; set; } = string.Empty;

    public Table GetTableName() => Table.users;
}
