using System.ComponentModel;

namespace Library_Management_System.Enums;

public enum LogicalOperators
{
    [Description("None.")]
    None,
    [Description("TRUE if all the conditions separated by AND is TRUE.")]
    AND,
    [Description("TRUE if any of the conditions separated by OR is TRUE.")]
    OR
}

public static class LogicalOperatorConverter
{
    public static string? Convert(LogicalOperators operation)
    {
        return operation switch
        {
            LogicalOperators.None => null,
            LogicalOperators.AND => " AND ",
            LogicalOperators.OR => " OR ",
            _ => " AND ",
        };
    }
}