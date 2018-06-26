namespace FLDCLegacyDataMigrator.Services.Concrete
{
    using System.Linq;

    using FLDCLegacyDataMigrator.Services.Abstract;

    public class MigratorProvider : IMigratorService
    {
        private readonly IDataMappingService dataMappingService;

        private readonly ICommandLineArgumentsValidatorService inputValidator;

        private readonly ILegacyDbDumpReaderService legacyDbDumpReader;

        private readonly ILoggingService loggingService;

        private readonly IStatsDataWriterService statsDataWriter;

        public MigratorProvider(
            ILoggingService loggingService,
            ICommandLineArgumentsValidatorService inputValidator,
            ILegacyDbDumpReaderService legacyDbDumpReader,
            IDataMappingService dataMappingService,
            IStatsDataWriterService statsDataWriter)
        {
            this.loggingService = loggingService;
            this.inputValidator = inputValidator;
            this.legacyDbDumpReader = legacyDbDumpReader;
            this.legacyDbDumpReader.RecordsForDayRead += LegacyDbDumpReader_RecordsForDayRead;
            this.dataMappingService = dataMappingService;
            this.statsDataWriter = statsDataWriter;
        }

        public int Execute(string[] args)
        {
            loggingService.LogDebug("Begin Execution");

            var result = inputValidator.Validate(args);
            if (result == Constants.ErrorCodes.Success)
            {
                result = legacyDbDumpReader.ReadData(args[0].Trim());
            }

            loggingService.LogDebug("End Execution");
            return result;
        }

        private void LegacyDbDumpReader_RecordsForDayRead(object sender, RecordsForDayReadEventArgs e)
        {
            loggingService.LogDebug($"Batch Read: {e.Records.First().Date} - {e.Records.Count()} record(s)");
            // TODO: Write out the records in stats file format
            // 1. Calculate filename, based on source date
            // 2. Map data
            // 3. Write to stats format
            // 4. Zip the file
        }
    }
}