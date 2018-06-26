namespace FLDCLegacyDataMigrator.Services.Concrete
{
    using System.IO;

    using FLDCLegacyDataMigrator.Services.Abstract;

    using ICSharpCode.SharpZipLib.BZip2;

    public class BZip2FileCompressionProvider : IFileCompressionService
    {
        public void CompressFile(string sourceFilename, string compressedFilename)
        {
            using (var sourceStream = new FileStream(sourceFilename, FileMode.Open))
            {
                using (var compressedStream = new FileStream(compressedFilename, FileMode.OpenOrCreate))
                {
                    BZip2.Compress(sourceStream, compressedStream, false, 5);
                }
            }
        }
    }
}