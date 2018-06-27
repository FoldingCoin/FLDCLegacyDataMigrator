namespace FLDCLegacyDataMigrator.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FLDCLegacyDataMigrator.Entity;
    using FLDCLegacyDataMigrator.Services.Abstract;
    using FLDCLegacyDataMigrator.Services.Concrete;

    using NSubstitute;

    using NUnit.Framework;

    [TestFixture]
    public class MigratorProviderTests
    {
        private IDataMappingService dataMappingServiceMock;

        private IFileCompressionService fileCompressionServiceMock;

        private IFileSystemOperationsService fileSystemOperationsServiceMock;

        private ILegacyDbDumpReaderService legacyDbDumpReaderMock;

        private ILoggingService loggingServiceMock;

        private IStatsDataWriterService statsDataWriterMock;

        private MigratorProvider systemUnderTest;

        private ICommandLineArgumentsValidatorService validatorMock;

        [Test]
        public void Execute_WhenArgsValid_ReadsInputFile()
        {
            var args = new[] { " arg1 ", "arg2" };
            validatorMock.Validate(args).Returns(Constants.ErrorCodes.Success);

            systemUnderTest.Execute(args);

            legacyDbDumpReaderMock.Received(1).ReadData("arg1");
        }

        [TestCase(Constants.ErrorCodes.Success)]
        [TestCase(Constants.ErrorCodes.InvalidInputFileName)]
        [TestCase(Constants.ErrorCodes.OutputDirectoryDoesNotExist)]
        public void Execute_WhenArgsValid_ReturnsResultFromReader(int expectedCode)
        {
            var args = new[] { " arg1 ", "arg2" };
            validatorMock.Validate(args).Returns(Constants.ErrorCodes.Success);
            legacyDbDumpReaderMock.ReadData("arg1").Returns(expectedCode);

            var actual = systemUnderTest.Execute(args);

            Assert.That(actual, Is.EqualTo(expectedCode));
        }

        [Test]
        public void Execute_WhenInvoked_LogsBeginAndEnd()
        {
            systemUnderTest.Execute(new[] { "arg1", "arg2" });

            loggingServiceMock.Received(1).LogDebug("Begin Execution");
            loggingServiceMock.Received(1).LogDebug("End Execution");
        }

        [TestCase(Constants.ErrorCodes.Success)]
        [TestCase(Constants.ErrorCodes.InvalidInputFileName)]
        [TestCase(Constants.ErrorCodes.OutputDirectoryDoesNotExist)]
        public void Execute_WhenInvoked_ReturnsValidatorResult(int expectedCode)
        {
            var args = new[] { "arg1", "arg2" };
            validatorMock.Validate(args).Returns(expectedCode);

            var actual = systemUnderTest.Execute(args);

            Assert.That(actual, Is.EqualTo(expectedCode));
        }

        [Test]
        public void Execute_WhenInvoked_ValidatesArgs()
        {
            var args = new[] { "arg1", "arg2" };

            systemUnderTest.Execute(args);

            validatorMock.Received(1).Validate(args);
        }

        [Test]
        public void Execute_WhenLegacyReaderRecordsForDayReadFires_CompressesStatsFiles()
        {
            var outputRecords = new List<StatsDataItem>();
            outputRecords.Add(new StatsDataItem());
            var inputRecords = SetUpLegacyDataReader();
            dataMappingServiceMock.MapData(inputRecords).Returns(outputRecords);
            var outputFilename = SetUpStatsFileIntermediateOutputFilename(inputRecords);
            var tempCompressedFilename = @"c:\path\to\tmp\tmpfile.tmp";
            fileSystemOperationsServiceMock.GetTempFilename().Returns(tempCompressedFilename);

            systemUnderTest.Execute(new[] { "arg1", "arg2" });

            fileCompressionServiceMock.Received(1).CompressFile(outputFilename, tempCompressedFilename);
        }

        [Test]
        public void Execute_WhenLegacyReaderRecordsForDayReadFires_MapsRecords()
        {
            var inputRecords = SetUpLegacyDataReader();

            systemUnderTest.Execute(new[] { "arg1", "arg2" });

            dataMappingServiceMock.Received(1).MapData(inputRecords);
        }

        [Test]
        public void Execute_WhenLegacyReaderRecordsForDayReadFires_MovesCompressedFileToOutputFolder()
        {
            var outputRecords = new List<StatsDataItem>();
            outputRecords.Add(new StatsDataItem());
            var inputRecords = SetUpLegacyDataReader();
            dataMappingServiceMock.MapData(inputRecords).Returns(outputRecords);
            SetUpStatsFileIntermediateOutputFilename(inputRecords);
            var tempCompressedFilename = @"c:\path\to\tmp\tmpfile.tmp";
            fileSystemOperationsServiceMock.GetTempFilename().Returns(tempCompressedFilename);
            fileCompressionServiceMock.FileExt.Returns(".bz2");
            var outputFilename =
                $"c:\\path\\to\\output\\FoldingStatsData-{inputRecords.First().Date.ToString("yyyyMMdd")}.txt.bz2";

            systemUnderTest.Execute(new[] { "arg1", @"c:\path\to\output" });

            fileSystemOperationsServiceMock.Received(1).MoveFile(tempCompressedFilename, outputFilename);
        }

        [Test]
        public void Execute_WhenLegacyReaderRecordsForDayReadFires_RemovesTempFile()
        {
            var outputRecords = new List<StatsDataItem>();
            outputRecords.Add(new StatsDataItem());
            var inputRecords = SetUpLegacyDataReader();
            dataMappingServiceMock.MapData(inputRecords).Returns(outputRecords);
            var intermediateOutputFilename = SetUpStatsFileIntermediateOutputFilename(inputRecords);
            var tempCompressedFilename = @"c:\path\to\tmp\tmpfile.tmp";
            fileSystemOperationsServiceMock.GetTempFilename().Returns(tempCompressedFilename);
            fileSystemOperationsServiceMock.FileExists(intermediateOutputFilename).Returns(true);

            systemUnderTest.Execute(new[] { "arg1", @"c:\path\to\output" });

            fileSystemOperationsServiceMock.Received(1).DeleteFile(intermediateOutputFilename);
        }

        [Test]
        public void Execute_WhenLegacyReaderRecordsForDayReadFires_WritesStatsFiles()
        {
            var outputRecords = new List<StatsDataItem>();
            outputRecords.Add(new StatsDataItem());
            var inputRecords = SetUpLegacyDataReader();
            dataMappingServiceMock.MapData(inputRecords).Returns(outputRecords);
            var outputFilename = SetUpStatsFileIntermediateOutputFilename(inputRecords);

            systemUnderTest.Execute(new[] { "arg1", "arg2" });

            statsDataWriterMock.Received(1).Write(outputRecords, inputRecords.First().Date, outputFilename);
        }

        [SetUp]
        public void SetUp()
        {
            loggingServiceMock = Substitute.For<ILoggingService>();
            validatorMock = Substitute.For<ICommandLineArgumentsValidatorService>();
            legacyDbDumpReaderMock = Substitute.For<ILegacyDbDumpReaderService>();
            dataMappingServiceMock = Substitute.For<IDataMappingService>();
            fileSystemOperationsServiceMock = Substitute.For<IFileSystemOperationsService>();
            statsDataWriterMock = Substitute.For<IStatsDataWriterService>();
            fileCompressionServiceMock = Substitute.For<IFileCompressionService>();
            systemUnderTest = new MigratorProvider(
                loggingServiceMock,
                validatorMock,
                legacyDbDumpReaderMock,
                dataMappingServiceMock,
                fileSystemOperationsServiceMock,
                statsDataWriterMock,
                fileCompressionServiceMock);
        }

        private IEnumerable<LegacyDataItem> SetUpLegacyDataReader()
        {
            var inputRecords = new List<LegacyDataItem>();
            inputRecords.Add(new LegacyDataItem { Date = new DateTime(2001, 9, 11) });
            legacyDbDumpReaderMock.WhenForAnyArgs(x => x.ReadData("arg1")).Do(
                x =>
                    {
                        legacyDbDumpReaderMock.RecordsForDayRead +=
                            Raise.EventWith(new RecordsForDayReadEventArgs(inputRecords));
                    });
            return inputRecords;
        }

        private string SetUpStatsFileIntermediateOutputFilename(IEnumerable<LegacyDataItem> inputRecords)
        {
            var tempDir = @"c:\path\to\tmp";
            fileSystemOperationsServiceMock.GetTempPath().Returns(tempDir);
            return $"{tempDir}\\FoldingStatsData-{inputRecords.First().Date.ToString("yyyyMMdd")}.txt";
        }
    }
}