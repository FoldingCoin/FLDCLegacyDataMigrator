namespace FLDCLegacyDataMigrator.Tests
{
    using System.IO;
    using System.Reflection;

    public class TestsWithResourcesBase
    {
        protected string ExtractTestDataFile(string resourceName)
        {
            using (var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                var tempFile = Path.GetTempFileName();
                using (var targetStream = new FileStream(tempFile, FileMode.OpenOrCreate))
                {
                    resourceStream.CopyTo(targetStream);
                    return tempFile;
                }
            }
        }

        protected void RemoveFile(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
        }
    }
}