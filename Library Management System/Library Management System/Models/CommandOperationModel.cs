namespace Library_Management_System.Models;

public class CommandOperationModel
{
    public required string Column { get; set; } = "ID";
    public required object Value { get; set; }
    public ComparisonOperators ComparisonOperator { get; set; } = ComparisonOperators.EqualTo;
    public LogicalOperators LogicalOperator { get; set; } = LogicalOperators.AND;
}
