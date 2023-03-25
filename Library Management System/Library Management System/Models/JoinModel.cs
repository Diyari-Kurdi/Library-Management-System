namespace Library_Management_System.Models;

public class JoinModel<T> where T : class
{
    public required T FristTable { get; set; }
    public required Table FirstTableName { get; set; }
    public required JoinTableModel[] JoinTables { get; set; }
}

public class JoinTableModel
{
    public Table? TableName { get; set; }
    public string ColumnName { get; set; } = "ID";
    public JoinType JoinType { get; set; } = JoinType.InnerJoin;
}
public class FirstJoinTableModel
{
    public Table? TableName { get; set; }
    public required string[] Columns { get; set; }
}