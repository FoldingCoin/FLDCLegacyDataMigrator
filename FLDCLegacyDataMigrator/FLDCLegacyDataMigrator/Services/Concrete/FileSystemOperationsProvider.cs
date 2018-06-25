namespace FLDCLegacyDataMigrator.Services.Concrete
{
    using System.IO;
    using System.Text;

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

        public StreamReader OpenFileStreamReader(string filename)
        {
            return new StreamReader(filename, Encoding.UTF8);
        }

        public StreamWriter OpenFileStreamWriter(string filename)
        {
            return new StreamWriter(filename, false, Encoding.UTF8);
        }
    }
}