using Dapper;
using Microsoft.UI.Xaml.Controls;
using MySqlConnector;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Library_Management_System.Services;

internal static class ServerSetupService
{
    /// <summary>
    /// Check if the connection is valid.
    /// </summary>
    /// <param name="server"></param>
    public static async Task<bool> IsConnectionValid(ServerModel server, InfoBar infoBar, CancellationToken cancellationToken)
    {
        using MySqlConnection con = new($"{server.ConnectionString}Password={server.RootPassword.Password}");
        try
        {
            await con.OpenAsync(cancellationToken);
            await con.PingAsync(cancellationToken);
            return true;
        }
        catch (OperationCanceledException ex)
        {
            infoBar.Show(ex, Severity: InfoBarSeverity.Informational);
            return false;
        }
        catch (MySqlException ex)
        {
            infoBar.Show(ex);
            return false;
        }
    }

    /// <summary>
    /// Setup the Server Base for our project
    /// </summary>
    /// <param name="tables"></param>
    /// <param name="admin"></param>
    public static async Task<bool> SetupServerAsync(TableModel[] tables, UserModel admin, InfoBar infoBar)
    {
        try
        {
            using MySqlConnection connection = new(TempData.ServerModel!.ConnectionString);
            //Creating Database
            await connection.ExecuteAsync($"CREATE DATABASE `{TempData.ServerModel.DatabaseName}`;");
            //Creating Tables
            foreach (var table in tables)
            {
                string sql = QueryGeneratorService.GetTableQuery(table);
                await connection.ExecuteAsync(sql);
            }
            //Inserting Data
            await connection.ExecuteAsync($"INSERT INTO `{TempData.ServerModel.DatabaseName}`.`{Table.users}` (`Username`,`Password`,`Avatar`) VALUES(@username,@password,@avatar);", admin);
            return true;

        }
        catch (Exception ex)
        {
            infoBar.Show(ex);
            return false;
        }
    }
}
