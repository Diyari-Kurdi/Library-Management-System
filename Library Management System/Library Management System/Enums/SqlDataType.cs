namespace Library_Management_System.Enums;

public enum SqlDataType
{
    //Strings
    CHAR,
    NCHAR,
    VARCHAR,
    NVARCHAR,
    BINARY,
    VARBINARY,
    TINYBLOB,
    TINYTEXT,
    TEXT,
    BLOB,
    MEDIUMTEXT,
    MEDIUMBLOB,
    LONGTEXT,
    LONGBLOB,
    ENUM,
    SET,

    //Integer
    BIT,
    TINYINT,
    BOOLEAN,
    SMALLINT,
    MEDIUMINT,
    INT,
    BIGINT,
    FLOAT,
    DOUBLE,
    DECIMAL,

    //Datetime
    DATE,
    DATETIME,
    TIME,
    TIMESTAMP,
    YEAR,

    //Array
    JSON
}

public class SqlDataTypeConverter
{
    public static string GetDataType(SqlDataType dataType, object? value = null)
    {
        if (value == null)
            return dataType.ToString();
        return $"{dataType}({value})";
    }
}