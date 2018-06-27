namespace FLDCLegacyDataMigrator.Services.Abstract
{
    using System.IO;

    public interface IFileSystemOperationsService
    {
        void DeleteFile(string filename);

        bool DirectoryExists(string path);

        bool FileExists(string filename);

        string GetTempFilename();

        string GetTempPath();

        void MoveFile(string from, string to);

        StreamReader OpenFileStreamReader(string filename);

        StreamWriter OpenFileStreamWriter(string filename);
    }
}