namespace FLDCLegacyDataMigrator.Tests
{
    using System.IO;
    using System.Reflection;

    using FLDCLegacyDataMigrator.Services.Concrete;

    using NUnit.Framework;

    [TestFixture]
    public class LegacyDbDumpReaderProviderTests
    {
        private LegacyDbDumpReaderProvider systemUnderTest;

        private string testDataFilename;

        [Test]
        public void ReadData_WhenInvokedOnValidFile_ReturnsSuccess()
        {
            var actual = systemUnderTest.ReadData(testDataFilename);

            Assert.That(actual, Is.EqualTo(Constants.ErrorCodes.Success));
        }

        [SetUp]
        public void SetUp()
        {
            var fileSystemOperations = new FileSystemOperationsProvider();
            systemUnderTest = new LegacyDbDumpReaderProvider(fileSystemOperations);
            ExtractTestDataFile();
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(testDataFilename))
            {
                File.Delete(testDataFilename);
            }
        }

        private void ExtractTestDataFile()
        {
            using (var resourceStream = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream("FLDCLegacyDataMigrator.Tests.TestData.TestLegacyDbDump.sql"))
            {
                testDataFilename = Path.GetTempFileName();
                using (var targetStream = new FileStream(testDataFilename, FileMode.OpenOrCreate))
                {
                    resourceStream.CopyTo(targetStream);
                }
            }
        }
    }
}