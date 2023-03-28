using Dapper;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;


namespace Library_Management_System.Services;

public static class SQLiteService
{
    #region MySql
    private static readonly string ConnectionString = @$"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Library.db")}";

    #endregion

    #region Check

    /// <summary>
    /// Check If Value Exist
    /// </summary>
    /// <param name="table"></param>
    /// <param name="ColumnName"></param>
    /// <param name="Value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<object> IsExist(Table table, string ColumnName, object Value, CancellationToken cancellationToken)
    {
        using SQLiteConnection connection = new(ConnectionString);
        try
        {
            var result = await connection.QueryAsync<int>(new($"SELECT COUNT(*) FROM `{table}` WHERE `{ColumnName}`=@value", new { value = Value },
                cancellationToken: cancellationToken));
            if (result.First() > 0)
            {
                return true;
            };
            return false;
        }
        catch (SQLiteException ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Check for multiple Values if Exist using AND , OR Operators
    /// </summary>
    /// <param name="table"></param>
    /// <param name="operationModels"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>True if the value exists.</returns>
    public static async Task<bool> IsExist(Table table, CommandOperationModel[] operationModels, InfoBar? infoBar, CancellationToken cancellationToken)
    {
        using SQLiteConnection connection = new(ConnectionString);
        try
        {
            string cols = string.Empty;
            if (operationModels.Length > 0)
            {
                foreach (CommandOperationModel operationModel in operationModels)
                {
                    cols += $"`{operationModel.Column}`{ComparisonOperatorConverter.Convert(operationModel.ComparisonOperator)}'{operationModel.Value}'";

                    string? logicalOperator = LogicalOperatorConverter.Convert(operationModel.LogicalOperator);
                    if (logicalOperator == null)
                        break;
                    cols += logicalOperator;
                }

                int result = await connection.QuerySingleAsync<int>(new($"SELECT COUNT(*) FROM `{table}` WHERE {cols};", cancellationToken: cancellationToken));
                if (result > 0)
                {
                    return true;
                };
            }
            return false;
        }
        catch (SQLiteException ex)
        {
            infoBar?.Show(ex.Message);
            return false;
        }
    }

    public static async Task<bool> Login(Table table, string? Username, string Password, InfoBar infoBar, CancellationToken cancellationToken)
    {
        using SQLiteConnection connection = new(ConnectionString);
        try
        {
            string cols = string.Empty;
            int result = await connection.QuerySingleAsync<int>(new($"SELECT COUNT(*) FROM `{table}` WHERE `Username` = @username AND `Password` = @password",
                new { username = Username, password = Password }, cancellationToken: cancellationToken));
            if (result > 0)
            {
                return true;
            }
            infoBar.Show("Incorrect Password.");

            return false;
        }
        catch (InvalidOperationException)
        {
            infoBar.Show($"Invalid Username or Password.");
            return false;
        }
        catch (SQLiteException ex)
        {
            infoBar.Show(ex.Message);
            return false;
        }
        catch (OperationCanceledException)
        {
            return false;
        }
        catch (Exception ex)
        {
            infoBar.Show(ex.Message);
            return false;
        }
    }


    #endregion

    #region Select

    /// <summary>
    /// Select A Table.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns><see cref="IEnumerable<T>"/></returns>
    public static async Task<IEnumerable<T>?> SelectAsync<T>(CancellationToken cancellationToken)
        where T : ITableModel
    {
        using SQLiteConnection connection = new(ConnectionString);
        try
        {
            ITableModel? model = Activator.CreateInstance(typeof(T)) as ITableModel;
            var sql = $"SELECT * FROM `{model?.GetTableName()}`";
            var query = await connection.QueryAsync<T>(new CommandDefinition(sql, cancellationToken: cancellationToken));
            return query;
        }
        catch (SQLiteException ex)
        {
            throw ex;
        }
        catch (OperationCanceledException ex)
        {
            throw ex;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            throw;
        }
    }

    public static async Task<T?> SelectAsync<T>(CommandOperationModel[] operationModels, string[]? columns = null, InfoBar? infoBar = null, CancellationToken? ct = null)
        where T : ITableModel
    {
        CancellationToken cancellationToken;
        if (ct is not null)
            cancellationToken = (CancellationToken)ct;
        else
            cancellationToken = CancellationToken.None;

        using SQLiteConnection connection = new(ConnectionString);
        try
        {
            ITableModel? model = Activator.CreateInstance(typeof(T)) as ITableModel;
            string cols = string.Empty;
            if (operationModels.Length > 0)
            {
                foreach (CommandOperationModel operationModel in operationModels)
                {
                    cols += $"`{operationModel.Column}`{ComparisonOperatorConverter.Convert(operationModel.ComparisonOperator)}'{operationModel.Value}'";

                    string? logicalOperator = LogicalOperatorConverter.Convert(operationModel.LogicalOperator);
                    if (logicalOperator == null)
                        break;
                    cols += logicalOperator;
                }
                string SelectedColumns = "*";

                if (columns != null)
                {
                    SelectedColumns = string.Empty;
                    foreach (var item in columns)
                    {
                        SelectedColumns += $"`{item}` ,";
                    }
                }

                SelectedColumns = SelectedColumns.TrimEnd(',');
                var x = $"SELECT {SelectedColumns} FROM `{model!.GetTableName()}` WHERE {cols};";
                return await connection.QuerySingleAsync<T>(new($"SELECT {SelectedColumns} FROM `{model!.GetTableName()}` WHERE {cols};", cancellationToken: cancellationToken));
            }
            return default;
        }
        catch (SQLiteException ex)
        {
            infoBar?.Show(ex.Message);
            return default;
        }
    }
    public static async Task<IEnumerable<FullBookModel>> SelectFullBooksAsync()
    {
        try
        {
            using SQLiteConnection connection = new(ConnectionString);
            string sql = $"SELECT _first.*, _second.*, _third.* FROM `{Table.books}` _first " +
                $"LEFT JOIN `{Table.authors}` _second ON _first.AuthorID = _second.ID " +
                $"LEFT JOIN `{Table.categories}` _third ON _first.GenreID = _third.ID;";

            var results = await connection.QueryAsync<FullBookModel, AuthorModel, CategoryModel, FullBookModel>
                (sql, (first, second, third) =>
                {
                    first.Author = second.FullName;
                    first.Genre = third.Genre;
                    return first;
                }, splitOn: "ID");
            return results;
        }
        catch (SQLiteException ex)
        {
            throw ex;
        }
        catch (OperationCanceledException ex)
        {
            throw ex;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            throw;
        }
    }

    public static async Task<IEnumerable<AuthorModel>?> SelectAuthorsAsync()
    {
        try
        {
            using SQLiteConnection connection = new(ConnectionString);
            string sql = $"SELECT * FROM `{Table.authors}` ;";
            var authors = await SelectAsync<AuthorModel>(CancellationToken.None);
            var books = await SelectFullBooksAsync();

            if (authors != null && books != null)
                foreach (var author in authors)
                {
                    author.Books = new(books.Where(book => book.AuthorID == author.ID));
                }
            return authors;
        }
        catch (SQLiteException ex)
        {
            throw ex;
        }
        catch (OperationCanceledException ex)
        {
            throw ex;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            throw;
        }
    }

    #endregion

    #region Insert

    /// <summary>
    /// Inserting Single/Multiple Rows asynchronously.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="type"></param>
    /// <param name="infoBar"></param>
    /// <param name="cT"></param>
    /// <returns><see cref="int"/> number of rows affected.</returns>
    public static async Task<int> InsertAsync<T>(T type, InfoBar? infoBar, CancellationToken cT)
        where T : ITableModel
    {
        var parameters = new DynamicParameters();
        string vals = string.Empty;
        List<string> columnsName = new();
        List<string> values = new();
        List<List<string>> ListsOfValues = new();
        PropertyInfo[] Properties;
        //If it was a list then Add Columns name out of Properties.
        if (type is IList genericList)
        {
            var gList = genericList[0]!.GetType().GetProperties();
            foreach (var property in gList)
            {
                if (property.Name != "ID" && property.PropertyType != typeof(ImageSource) && property.PropertyType != typeof(ObservableCollection<FullBookModel>))
                {
                    columnsName.Add(property.Name);
                }
            }

            for (int i = 0; i < genericList.Count; i++)
            {
                values = new();
                var list = genericList[i]!.GetType().GetProperties();
                foreach (var property in list)
                {
                    if (property.Name != "ID" && property.PropertyType != typeof(ImageSource) && property.PropertyType != typeof(ObservableCollection<FullBookModel>))
                    {
                        parameters.Add($"@{property.Name}{i}", property.GetValue(genericList[i]));
                        values.Add($"@{property.Name}{i}");
                    }
                }
                ListsOfValues.Add(values);
            }
        }
        else
        {
            Properties = type.GetType().GetProperties();
            foreach (var property in Properties)
            {
                if (property.Name != "ID" && property.CanWrite && property.PropertyType != typeof(ImageSource) && property.PropertyType != typeof(ObservableCollection<FullBookModel>))
                {
                    if (property.GetValue(type) is DateTimeOffset dateTimeOffset)
                    {
                        parameters.Add($"@{property.Name}", dateTimeOffset.Date.ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        parameters.Add($"@{property.Name}", property.GetValue(type));
                    }
                    columnsName.Add(property.Name);
                    values.Add($"@{property.Name}");
                }
            }
            ListsOfValues.Add(values);
        }

        foreach (var list in ListsOfValues)
        {
            vals += $"({string.Join(',', list)}),";
        }
        vals = vals.Remove(vals.Length - 1, 1);

        using SQLiteConnection connection = new(ConnectionString);
        try
        {
            var sql = $"INSERT INTO `{type.GetTableName()}` ({string.Join(',', columnsName)}) VALUES{vals};";
            var AffectedRows = await connection.ExecuteAsync(new(sql, parameters, cancellationToken: cT));
            return AffectedRows;
        }
        catch (OperationCanceledException) { return 0; }
        catch (SQLiteException ex)
        {
            infoBar?.Show(ex.Message);
            return 0;
        }
    }

    #endregion

    #region Delete

    public static async Task<int> DeleteAsync(ITableModel Record, string conditionColumn, InfoBar? infoBar, CancellationToken cancellationToken)
    {
        try
        {
            using SQLiteConnection connection = new(ConnectionString);
            var sql = $"DELETE FROM `{Record.GetTableName()}` WHERE `{conditionColumn}`=@{conditionColumn} ;";
            var AffectedRows = await connection.ExecuteAsync(new($"DELETE FROM `{Record.GetTableName()}` WHERE `{conditionColumn}`=@{conditionColumn};", Record, cancellationToken: cancellationToken));
            return AffectedRows;
        }
        catch (Exception ex)
        {
            infoBar?.Show(ex.Message);
            return 0;
        }
    }

    #endregion

    #region Update

    /// <summary>
    /// Update a single cell in a row.
    /// </summary>
    /// <returns></returns>
    public static async Task<int> UpdateAsync(int oldRecordID, ITableModel newRecord, InfoBar? infoBar, CancellationToken cancellationToken)
    {
        try
        {
            using SQLiteConnection connection = new(ConnectionString);
            var Properties = newRecord.GetType().GetProperties().Where(p => p.CanWrite && p.Name != "ID" && p.PropertyType != typeof(ImageSource) && p.PropertyType != typeof(ObservableCollection<FullBookModel>));
            string changes = string.Empty;
            foreach (var property in Properties)
            {
                var newValue = newRecord.GetType().GetProperty(property.Name)?.GetValue(newRecord);
                if (newValue is DateTimeOffset newVal)
                    newValue = newVal.Date.ToString("yyyy-MM-dd");
                changes += $"`{property.Name}` = '{newValue}',";
            }
            changes = changes.TrimEnd(',');
            var sql = $"UPDATE `{newRecord.GetTableName()}` SET {changes} WHERE `ID` = '{oldRecordID}';";
            var AffectedRows = await connection.ExecuteAsync(new(sql, cancellationToken: cancellationToken));
            return AffectedRows;
        }
        catch (SQLiteException ex)
        {
            infoBar?.Show(ex.Message);
            return 0;
        }
    }


    #endregion
}
