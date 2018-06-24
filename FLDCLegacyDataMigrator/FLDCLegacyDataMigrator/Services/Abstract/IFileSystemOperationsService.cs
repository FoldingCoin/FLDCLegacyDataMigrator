namespace FLDCLegacyDataMigrator.Services.Abstract
{
    using System.IO;

    public interface IFileSystemOperationsService
    {
        bool DirectoryExists(string path);

        bool FileExists(string filename);

        StreamReader OpenFileStreamReader(string filename);
    }
}