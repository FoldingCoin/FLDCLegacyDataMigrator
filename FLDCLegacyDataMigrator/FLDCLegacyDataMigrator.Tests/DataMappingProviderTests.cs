namespace FLDCLegacyDataMigrator.Tests
{
    using System;
    using System.Collections.Generic;

    using FLDCLegacyDataMigrator.Entity;
    using FLDCLegacyDataMigrator.Services.Concrete;

    using NUnit.Framework;

    [TestFixture]
    public class DataMappingProviderTests
    {
        private DataMappingProvider systemUnderTest;

        [Test]
        public void MapData_WhenInvoked_ReturnsCorrectlyMappedItems()
        {
            IEnumerable<LegacyDataItem> inputData = GenerateInputData();
            IEnumerable<StatsDataItem> expectedOutputData = GenerateExpectedData();

            var actual = systemUnderTest.MapData(inputData);

            AssertThatCollectionsAreEqual(actual, expectedOutputData);
        }

        [SetUp]
        public void SetUp()
        {
            systemUnderTest = new DataMappingProvider();
        }

        private void AssertThatCollectionsAreEqual(
            IEnumerable<StatsDataItem> actual,
            IEnumerable<StatsDataItem> expectedOutputData)
        {
            var actualList = new List<StatsDataItem>(actual);
            var expectedList = new List<StatsDataItem>(expectedOutputData);
            Assert.That(actualList.Count, Is.EqualTo(expectedList.Count), "Count");
            for (int i = 0; i < expectedList.Count; i++)
            {
                Assert.That(actualList[i].Name, Is.EqualTo(expectedList[i].Name), $"Name {i}");
                Assert.That(actualList[i].NewCredit, Is.EqualTo(expectedList[i].NewCredit), $"NewCredit {i}");
                Assert.That(actualList[i].SumTotal, Is.EqualTo(expectedList[i].SumTotal), $"SumTotal {i}");
                Assert.That(actualList[i].Team, Is.EqualTo(expectedList[i].Team), $"Team {i}");
            }
        }

        private IEnumerable<StatsDataItem> GenerateExpectedData()
        {
            yield return new StatsDataItem
                             { Name = "SomeName1_SomeToken1_SomeAddress1", NewCredit = 421, SumTotal = 0, Team = 0 };

            yield return new StatsDataItem
                             { Name = "SomeName2_SomeToken2_SomeAddress2", NewCredit = 422, SumTotal = 0, Team = 0 };
        }

        private IEnumerable<LegacyDataItem> GenerateInputData()
        {
            yield return new LegacyDataItem
                             {
                                 Name = "SomeName1", Address = "SomeAddress1", Token = "SomeToken1", TotalPoints = 421,
                                 Date = GetTestDate()
                             };

            yield return new LegacyDataItem
                             {
                                 Name = "SomeName2", Address = "SomeAddress2", Token = "SomeToken2", TotalPoints = 422,
                                 Date = GetTestDate()
                             };
        }

        private DateTime GetTestDate()
        {
            return new DateTime(2014, 07, 25);
        }
    }
}