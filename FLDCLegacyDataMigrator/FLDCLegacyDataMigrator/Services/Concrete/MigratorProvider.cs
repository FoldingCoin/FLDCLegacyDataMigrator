namespace FLDCLegacyDataMigrator.Services.Concrete
{
    using System.IO;
    using System.Linq;

    using FLDCLegacyDataMigrator.Services.Abstract;

    public class MigratorProvider : IMigratorService
    {
        private readonly IDataMappingService dataMappingService;

        private readonly IFileCompressionService fileCompressionService;

        private readonly IFileSystemOperationsService fileSystemOperationsService;

        private readonly ICommandLineArgumentsValidatorService inputValidator;

        private readonly ILegacyDbDumpReaderService legacyDbDumpReader;

        private readonly ILoggingService loggingService;

        private readonly IStatsDataWriterService statsDataWriter;

        private string outputPath;

        public MigratorProvider(
            ILoggingService loggingService,
            ICommandLineArgumentsValidatorService inputValidator,
            ILegacyDbDumpReaderService legacyDbDumpReader,
            IDataMappingService dataMappingService,
            IFileSystemOperationsService fileSystemOperationsService,
            IStatsDataWriterService statsDataWriter,
            IFileCompressionService fileCompressionService)
        {
            this.loggingService = loggingService;
            this.inputValidator = inputValidator;
            this.legacyDbDumpReader = legacyDbDumpReader;
            this.legacyDbDumpReader.RecordsForDayRead += LegacyDbDumpReader_RecordsForDayRead;
            this.dataMappingService = dataMappingService;
            this.fileSystemOperationsService = fileSystemOperationsService;
            this.statsDataWriter = statsDataWriter;
            this.fileCompressionService = fileCompressionService;
        }

        public int Execute(string[] args)
        {
            loggingService.LogDebug("Begin Execution");

            var result = inputValidator.Validate(args);
            if (result == Constants.ErrorCodes.Success)
            {
                outputPath = args[1].Trim();
                result = legacyDbDumpReader.ReadData(args[0].Trim());
            }

            loggingService.LogDebug("End Execution");
            return result;
        }

        private void LegacyDbDumpReader_RecordsForDayRead(object sender, RecordsForDayReadEventArgs e)
        {
            loggingService.LogDebug($"Batch Read: {e.Records.First().Date} - {e.Records.Count()} record(s)");

            // Map the data
            var statsData = dataMappingService.MapData(e.Records);

            // Build filenames
            var filename = $"FoldingStatsData-{e.Records.First().Date.ToString("yyyyMMdd")}.txt";
            var path = fileSystemOperationsService.GetTempPath();
            var fullPath = Path.Combine(path, filename);            
            var targetPath = Path.Combine(outputPath, filename + fileCompressionService.FileExt);

            // Remove intermediate file, if it already exists
            DeleteFileIfExists(fullPath);

            // Write the data in stats file format
            statsDataWriter.Write(statsData, e.Records.First().Date, fullPath);

            try
            {
                // Compress the stats file
                var tempFile = fileSystemOperationsService.GetTempFilename();
                fileCompressionService.CompressFile(fullPath, tempFile);

                // Move to output folder
                fileSystemOperationsService.MoveFile(tempFile, targetPath);
            }
            finally
            {
                // Cleanup
                DeleteFileIfExists(fullPath);
            }
        }

        private void DeleteFileIfExists(string fullPath)
        {
            if (fileSystemOperationsService.FileExists(fullPath))
            {
                fileSystemOperationsService.DeleteFile(fullPath);
            }
        }
    }
}