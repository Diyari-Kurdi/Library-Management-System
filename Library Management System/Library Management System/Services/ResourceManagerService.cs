using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Windows.Storage;

namespace Library_Management_System.Services;

public static class ResourceManagerService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="storageFile"></param>
    /// <returns>File destination</returns>
    public static async Task<string> AddFile(this StorageFile storageFile)
    {

        if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Images"))
        {
            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Images");
        }
        string newDest = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\Images", storageFile.Name);
        await CopyFileAsync(storageFile.Path, newDest);
        if (await TryOpen(newDest))
        {
            return newDest.Replace(@"\", @"/");
        }
        //throw new Exception();
        return storageFile.Path.Replace(@"\", @"/");
    }
    private static async Task<bool> TryOpen(string filePath)
    {
        while (true)
        {
            try
            {
                using FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                await fileStream.DisposeAsync();
                return true;
            }
            catch (IOException)
            {
                await Task.Delay(1000, CancellationToken.None);
            }
        }
    }
    public static async Task CopyFileAsync(string sourcePath, string destinationPath)
    {
        using Stream source = File.Open(sourcePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        using Stream destination = File.Create(destinationPath);
        await source.CopyToAsync(destination);
    }
}
