namespace FLDCLegacyDataMigrator.Tests
{
    using System.Collections.Generic;

    using FLDCLegacyDataMigrator.Entity;
    using FLDCLegacyDataMigrator.Services.Abstract;
    using FLDCLegacyDataMigrator.Services.Concrete;

    using NSubstitute;

    using NUnit.Framework;

    [TestFixture]
    public class LegacyDbDumpReaderProviderTests : TestsWithResourcesBase
    {
        private string corruptDataFilename;

        private string emptyFileFilename;

        private ILoggingService loggingServiceMock;

        private LegacyDbDumpReaderProvider systemUnderTest;

        private string testDataFilename;

        [Test]
        public void ReadData_WhenInvokedOnCorruptFile_FiresWarnings()
        {
            systemUnderTest.ReadData(corruptDataFilename);

            loggingServiceMock.Received(1)
                .LogWarning("Row could not be parsed: (3, 'FatHom', 'ALL', '1NSvYD7W2AT7hKdja3BQ),");
            loggingServiceMock.Received(1).LogWarning(
                "Row could not be parsed: (17, 'TSC!TeamServer', 'FLDC', '1P8bne5rA11dEvX2xuN9tdXdcDHU2j4Xpw'),");
        }

        [Test]
        public void ReadData_WhenInvokedOnEmptyFile_ReturnsCorrectErrorCode()
        {
            var actual = systemUnderTest.ReadData(emptyFileFilename);

            Assert.That(actual, Is.EqualTo(Constants.ErrorCodes.EmptyInputFile));
        }

        [Test]
        public void ReadData_WhenInvokedOnValidFile_BatchEventFiresForEachDay()
        {
            var batches = new List<List<LegacyDataItem>>();
            systemUnderTest.RecordsForDayRead += (sender, args) =>
                {
                    batches.Add(new List<LegacyDataItem>(args.Records));
                };

            systemUnderTest.ReadData(testDataFilename);

            Assert.That(batches.Count, Is.EqualTo(2));
            Assert.That(batches[0].Count, Is.EqualTo(72));
            Assert.That(batches[1].Count, Is.EqualTo(92));
        }

        [Test]
        public void ReadData_WhenInvokedOnValidFile_CorrectlyParsesData()
        {
            var batches = new List<List<LegacyDataItem>>();
            systemUnderTest.RecordsForDayRead += (sender, args) =>
                {
                    batches.Add(new List<LegacyDataItem>(args.Records));
                };

            systemUnderTest.ReadData(testDataFilename);

            // Spotcheck first and last record of each INSERT statement
            Assert.That(batches[0][0].Id, Is.EqualTo(1));
            Assert.That(batches[0][0].Name, Is.EqualTo("tguskill"));
            Assert.That(batches[0][0].Token, Is.EqualTo("FLDC"));
            Assert.That(batches[0][0].Address, Is.EqualTo("14meWrVap2pmUBrRwY1tBufhG9gXsxKw3N"));
            Assert.That(batches[0][0].TotalPoints, Is.EqualTo(1188582883));

            Assert.That(batches[0][35].Id, Is.EqualTo(36));
            Assert.That(batches[0][35].Name, Is.EqualTo("PADDBA"));
            Assert.That(batches[0][35].Token, Is.EqualTo("FLDC"));
            Assert.That(batches[0][35].Address, Is.EqualTo("1JyywCtA4ftkBtLdijTcvRSVCYZH2Jnhe9"));
            Assert.That(batches[0][35].TotalPoints, Is.EqualTo(53801918));

            Assert.That(batches[0][36].Id, Is.EqualTo(699));
            Assert.That(batches[0][36].Name, Is.EqualTo("Dendroid1812"));
            Assert.That(batches[0][36].Token, Is.EqualTo("FLDC"));
            Assert.That(batches[0][36].Address, Is.EqualTo("1DkpjU4J9zgTHidcDoDo9RmftxHJmWqbad"));
            Assert.That(batches[0][36].TotalPoints, Is.EqualTo(136614));

            Assert.That(batches[0][71].Id, Is.EqualTo(734));
            Assert.That(batches[0][71].Name, Is.EqualTo("---"));
            Assert.That(batches[0][71].Token, Is.EqualTo("FLDC"));
            Assert.That(batches[0][71].Address, Is.EqualTo("17ApKRTWkjn9f9NrkrB2iEJK4v5Tp7X6Z4"));
            Assert.That(batches[0][71].TotalPoints, Is.EqualTo(106875));

            Assert.That(batches[1][0].Id, Is.EqualTo(1));
            Assert.That(batches[1][0].Name, Is.EqualTo("tguskill"));
            Assert.That(batches[1][0].Token, Is.EqualTo("FLDC"));
            Assert.That(batches[1][0].Address, Is.EqualTo("14meWrVap2pmUBrRwY1tBufhG9gXsxKw3N"));
            Assert.That(batches[1][0].TotalPoints, Is.EqualTo(1194127699));

            Assert.That(batches[1][45].Id, Is.EqualTo(46));
            Assert.That(batches[1][45].Name, Is.EqualTo("4ebi"));
            Assert.That(batches[1][45].Token, Is.EqualTo("FLDC"));
            Assert.That(batches[1][45].Address, Is.EqualTo("1AbTjP3oJZJMPQjdNzdaVrRsANAKmo32KB"));
            Assert.That(batches[1][45].TotalPoints, Is.EqualTo(41437605));

            Assert.That(batches[1][46].Id, Is.EqualTo(699));
            Assert.That(batches[1][46].Name, Is.EqualTo("vach"));
            Assert.That(batches[1][46].Token, Is.EqualTo("ALL"));
            Assert.That(batches[1][46].Address, Is.EqualTo("16FxwsDM7MKgEA3Gk4JWjnD5xmRoAHjwUJ"));
            Assert.That(batches[1][46].TotalPoints, Is.EqualTo(137385));

            Assert.That(batches[1][91].Id, Is.EqualTo(744));
            Assert.That(batches[1][91].Name, Is.EqualTo("KarlAnders"));
            Assert.That(batches[1][91].Token, Is.EqualTo("ALL"));
            Assert.That(batches[1][91].Address, Is.EqualTo("1FjXd9MpXYA4yrPMsr5Khm9snvcEQLCNR2"));
            Assert.That(batches[1][91].TotalPoints, Is.EqualTo(100990));
        }

        [Test]
        public void ReadData_WhenInvokedOnValidFile_DoesNotLogWarnings()
        {
            systemUnderTest.ReadData(testDataFilename);

            loggingServiceMock.DidNotReceive().LogWarning(Arg.Any<string>());
        }

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
            loggingServiceMock = Substitute.For<ILoggingService>();
            systemUnderTest = new LegacyDbDumpReaderProvider(fileSystemOperations, loggingServiceMock);
            testDataFilename = ExtractTestDataFile("FLDCLegacyDataMigrator.Tests.TestData.TestLegacyDbDump.sql");
            emptyFileFilename = ExtractTestDataFile("FLDCLegacyDataMigrator.Tests.TestData.EmptyFile.sql");
            corruptDataFilename =
                ExtractTestDataFile("FLDCLegacyDataMigrator.Tests.TestData.TestLegacyDbDumpCorrupt.sql");
        }

        [TearDown]
        public void TearDown()
        {
            RemoveFile(testDataFilename);
            RemoveFile(emptyFileFilename);
            RemoveFile(corruptDataFilename);
        }
    }
}