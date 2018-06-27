namespace FLDCLegacyDataMigrator.Services.Abstract
{
    public interface IFileCompressionService
    {
        string FileExt { get; }

        void CompressFile(string sourceFilename, string compressedFilename);
    }
}