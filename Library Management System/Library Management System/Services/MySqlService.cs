using Dapper;
using Microsoft.UI.Xaml.Controls;
using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library_Management_System.Services;

internal static partial class MySqlService
{
    #region MySql

    private static readonly string DatabaseName = ApplicationSettings.Settings.DatabaseName;
    private static readonly string ConnectionString = ApplicationSettings.Settings.ConnectionString;

    #endregion

    #region Check

    /// <summary>
    /// Check if the connection is valid.
    /// </summary>
    /// <param name="server"></param>
    /// <returns><see cref="ResultsModel{T}"/></returns>
    public static async Task<bool> IsConnectionValid(ServerModel server, CancellationToken cancellationToken)
    {
        using MySqlConnection con = new($"{server.ConnectionString}Password={server.RootPassword.Password}");
        try
        {
            await con.OpenAsync(cancellationToken);
            await con.PingAsync(cancellationToken);
            return true;
        }
        catch
        {
            return false;
        }
    }

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
        using MySqlConnection connection = new(ConnectionString);
        try
        {
            var result = await connection.QueryAsync<int>(new($"SELECT COUNT(*) FROM `{DatabaseName}`.`{table}` WHERE `{ColumnName}`=@value", new { value = Value },
                cancellationToken: cancellationToken));
            if (result.First() > 0)
            {
                return true;
            };
            return false;
        }
        catch (MySqlException ex)
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
        using MySqlConnection connection = new(ConnectionString);
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

                int result = await connection.QuerySingleAsync<int>(new($"SELECT COUNT(*) FROM `{DatabaseName}`.`{table}` WHERE {cols};", cancellationToken: cancellationToken));
                if (result > 0)
                {
                    return true;
                };
            }
            return false;
        }
        catch (MySqlException ex)
        {
            infoBar?.Show(ex.Message);
            return false;
        }
    }

    public static async Task<bool> Login(Table table, string? Username, string Password, InfoBar infoBar, CancellationToken cancellationToken)
    {
        using MySqlConnection connection = new(ConnectionString);
        try
        {
            string cols = string.Empty;
            int result = await connection.QuerySingleAsync<int>(new($"SELECT COUNT(*) FROM `{DatabaseName}`.`{table}` WHERE `Username` = @username AND `Password` = @password",
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
        catch (MySqlException ex)
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
        using MySqlConnection connection = new(ConnectionString);
        try
        {
            ITableModel? model = Activator.CreateInstance(typeof(T)) as ITableModel;
            var sql = $"SELECT * FROM `{DatabaseName}`.`{model?.GetTableName()}`";
            var query = await connection.QueryAsync<T>(new CommandDefinition(sql, cancellationToken: cancellationToken));
            return query;
        }
        catch (MySqlException ex)
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

        using MySqlConnection connection = new(ConnectionString);
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
                var x = $"SELECT {SelectedColumns} FROM `{DatabaseName}`.`{model!.GetTableName()}` WHERE {cols};";
                return await connection.QuerySingleAsync<T>(new($"SELECT {SelectedColumns} FROM `{DatabaseName}`.`{model!.GetTableName()}` WHERE {cols};", cancellationToken: cancellationToken));
            }
            return default;
        }
        catch (MySqlException ex)
        {
            infoBar?.Show(ex.Message);
            return default;
        }
    }

    #endregion
}