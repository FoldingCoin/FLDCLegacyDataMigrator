namespace FLDCLegacyDataMigrator.Services.Concrete
{
    using System.IO;
    using System.Text;

    using FLDCLegacyDataMigrator.Services.Abstract;

    public class FileSystemOperationsProvider : IFileSystemOperationsService
    {
        public void DeleteFile(string filename)
        {
            File.Delete(filename);
        }

        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public bool FileExists(string filename)
        {
            return File.Exists(filename);
        }

        public string GetTempFilename()
        {
            return Path.GetTempFileName();
        }

        public string GetTempPath()
        {
            return Path.GetTempPath();
        }

        public void MoveFile(string from, string to)
        {
            File.Move(from, to);
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