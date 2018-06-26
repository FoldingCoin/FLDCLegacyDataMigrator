namespace FLDCLegacyDataMigrator.Services.Abstract
{
    public interface IFileCompressionService
    {
        void CompressFile(string sourceFilename, string compressedFilename);
    }
}