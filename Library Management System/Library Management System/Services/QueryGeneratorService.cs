using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System.Services;

public static class QueryGeneratorService
{
    public static string GetTableQuery(TableModel table)
    {
        StringBuilder sb = new();
        sb.Append($"USE `{TempData.ServerModel!.DatabaseName}`; CREATE TABLE `{table.Name}` (");
        List<string> PrimaryColumns = new();
        List<ForeignKeyModel> ForeignKeys = new();

        Array.ForEach(table.Columns, Column =>
        {
            sb.Append($"`{Column.Name}` {Column.DataType}");

            if (Column.IsNullable)
            {
                sb.Append(" NULL ");
            }
            else
            {
                sb.Append(" NOT NULL ");
            }

            if (!string.IsNullOrEmpty(Column.Default))
            {
                sb.Append($"DEFAULT {Column.Default}");
            }
            if (Column.IsAutoIncrament)
            {
                sb.Append(" AUTO_INCREMENT ");
            }
            if (Column.IsPrimaryKey)
            {
                PrimaryColumns.Add($"`{Column.Name}`");
            }
            if (Column.IsUnique)
            {
                sb.Append($", UNIQUE KEY `{Column.Name}_UNIQUE` (`{Column.Name}`)");
            }
            sb.Append(" , ");
            if (Column.HasForeignKey)
            {
                ForeignKeys.Add(new()
                {
                    ForeignKeyName = $"{table.Name}_{Column.ReferenceFromColumn}_{Column.ReferenceFromTable}_FK",
                    ForeignKeyFromTable = Column.ReferenceFromTable!,
                    ForeignKeyFromColumn = Column.ReferenceFromColumn!,
                    ForeignKeyToColumn = Column.Name
                });
            }
        });

        sb.Append($"PRIMARY KEY ({string.Join(',', PrimaryColumns)}) ");

        if (ForeignKeys.Count == 0)
        {
            sb.Append(')');
            sb.Append(" ENGINE=InnoDB;");
        }
        else
        {
            sb.Append(',');
            foreach (ForeignKeyModel foreignKeyModel in ForeignKeys)
            {
                sb.Append($"INDEX `{foreignKeyModel.ForeignKeyName}_{foreignKeyModel.ForeignKeyFromColumn}x` (`{foreignKeyModel.ForeignKeyToColumn}` ASC) VISIBLE, ");
                sb.Append($"CONSTRAINT `{foreignKeyModel.ForeignKeyName}` ");
                sb.Append($"FOREIGN KEY (`{foreignKeyModel.ForeignKeyToColumn}`) ");
                sb.Append($"REFERENCES `{TempData.ServerModel!.DatabaseName}`.`{foreignKeyModel.ForeignKeyFromTable}` (`{foreignKeyModel.ForeignKeyFromColumn}`) ");
                sb.Append($"ON DELETE NO ACTION ");
                sb.Append($"ON UPDATE NO ACTION");
                if (ForeignKeys.Count == 1)
                {
                    sb.Append(')');
                    sb.Append(" ENGINE=InnoDB;");
                }
                else
                {
                    sb.Append(", ");
                }
            }
            if (ForeignKeys.Count > 1)
            {
                sb = sb.Remove(sb.Length - 2, 2);
                sb.Append(')');
                sb.Append(" ENGINE=InnoDB;");
            }
        }

        return sb.ToString();
    }
}
