namespace FLDCLegacyDataMigrator.Services.Concrete
{
    using System.IO;

    using FLDCLegacyDataMigrator.Services.Abstract;

    public class FileSystemOperationsProvider : IFileSystemOperationsService
    {
        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public bool FileExists(string filename)
        {
            return File.Exists(filename);
        }
    }
}