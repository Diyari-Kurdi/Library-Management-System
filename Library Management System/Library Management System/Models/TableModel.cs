using System;

namespace Library_Management_System.Models;

public class TableModel
{
    public required string Name { get; set; }
    public required ColumnModel[] Columns { get; set; }
    public CellModel[] Cells { get; set; } = Array.Empty<CellModel>();
    public RowModel[] Rows { get; set; } = Array.Empty<RowModel>();
}