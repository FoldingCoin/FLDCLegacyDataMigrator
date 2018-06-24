namespace FLDCLegacyDataMigrator.Services.Abstract
{
    public interface IFileSystemOperationsService
    {
        bool DirectoryExists(string path);

        bool FileExists(string filename);
    }
}