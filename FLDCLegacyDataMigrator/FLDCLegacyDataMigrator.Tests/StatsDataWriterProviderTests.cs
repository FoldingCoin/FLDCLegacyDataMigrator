namespace FLDCLegacyDataMigrator.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using FLDCLegacyDataMigrator.Entity;
    using FLDCLegacyDataMigrator.Services.Concrete;

    using NUnit.Framework;

    [TestFixture]
    public class StatsDataWriterProviderTests : TestsWithResourcesBase
    {
        private string actualOutputFilename;

        private string expectedDataFilename;

        private StatsDataWriterProvider systemUnderTest;

        [SetUp]
        public void SetUp()
        {
            var fileSystemOperations = new FileSystemOperationsProvider();
            systemUnderTest = new StatsDataWriterProvider(fileSystemOperations);
            expectedDataFilename =
                ExtractTestDataFile("FLDCLegacyDataMigrator.Tests.TestData.ExpectedStatsDataOutput.txt");
            actualOutputFilename = Path.GetTempFileName();
        }

        [TearDown]
        public void TearDown()
        {
            RemoveFile(expectedDataFilename);
            RemoveFile(actualOutputFilename);
        }

        [Test]
        public void Write_WhenInvoked_GeneratesExpectedOutput()
        {
            var items = GenerateTestDataItems();
            var date = new DateTime(2017, 12, 26);

            systemUnderTest.Write(items, date, actualOutputFilename);

            var actual = File.ReadAllText(actualOutputFilename);
            var expected = File.ReadAllText(expectedDataFilename);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Write_WhenInvoked_ReturnsSuccess()
        {
            var items = GenerateTestDataItems();
            var date = new DateTime(2017, 12, 26);

            var actual = systemUnderTest.Write(items, date, actualOutputFilename);

            Assert.That(actual, Is.EqualTo(Constants.ErrorCodes.Success));
        }

        private IEnumerable<StatsDataItem> GenerateTestDataItems()
        {
            yield return new StatsDataItem
                             { Name = "PS3EdOlkkola", NewCredit = 458785, SumTotal = 25882218711, Team = 224497 };
            yield return new StatsDataItem { Name = "war", NewCredit = 544139, SumTotal = 20508731397, Team = 37651 };
            yield return new StatsDataItem
                             { Name = "msi_TW", NewCredit = 359312, SumTotal = 15889476570, Team = 31403 };
            yield return new StatsDataItem
                             { Name = "anonymous", NewCredit = 64221589, SumTotal = 13937689581, Team = 0 };
            yield return new StatsDataItem
                             { Name = "TheWasp", NewCredit = 734045, SumTotal = 13660834951, Team = 70335 };
            yield return new StatsDataItem
                             {
                                 Name = "tguskill_FLDC_14meWrVap2pmUBrRwY1tBufhG9gXsxKw3N", NewCredit = 180573,
                                 SumTotal = 11375904045, Team = 47191
                             };
            yield return new StatsDataItem
                             {
                                 Name = "vorksholk_ALL_1HsMGTTTWQQiSHyb7wFv4KALgACKofMqiU", NewCredit = 198913,
                                 SumTotal = 10974496743, Team = 224497
                             };
            yield return new StatsDataItem
                             {
                                 Name = "CUREfor_ALL_1forCUREZnmiUxGQ7qwjJ7AijUmPxt4LV", NewCredit = 153998,
                                 SumTotal = 10264904287, Team = 224497
                             };
        }
    }
}