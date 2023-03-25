using System.ComponentModel;

namespace Library_Management_System.Enums;

public enum ComparisonOperators
{
    [Description("=")]
    EqualTo = 0,
    [Description("<>")]
    NotEquals = 1,
    [Description(">=")]
    GreaterThanOrEqualTo = 2,
    [Description(">")]
    GreaterThan = 3,
    [Description("<")]
    LessThan = 4,
    [Description("<=")]
    LessThanOrEqualTo = 5
}

public static class ComparisonOperatorConverter
{
    public static string Convert(ComparisonOperators operation)
    {
        return operation switch
        {
            ComparisonOperators.EqualTo => "=",
            ComparisonOperators.NotEquals => "<>",
            ComparisonOperators.GreaterThanOrEqualTo => ">=",
            ComparisonOperators.GreaterThan => ">",
            ComparisonOperators.LessThan => "<",
            ComparisonOperators.LessThanOrEqualTo => "<=",
            _ => "=",
        };
    }
}