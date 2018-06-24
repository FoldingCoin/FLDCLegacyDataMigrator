namespace FLDCLegacyDataMigrator.Services.Concrete
{
    using System;

    using FLDCLegacyDataMigrator.Services.Abstract;

    public class LegacyDbDumpReaderProvider : ILegacyDbDumpReaderService
    {
        private readonly IFileSystemOperationsService fileSystemOperations;

        public LegacyDbDumpReaderProvider(IFileSystemOperationsService fileSystemOperations)
        {
            this.fileSystemOperations = fileSystemOperations;
        }

        public event EventHandler<RecordsForDayReadEventArgs> RecordsForDayRead;

        public int ReadData(string filename)
        {
            using (var reader = fileSystemOperations.OpenFileStreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (IsCreateTableStatement(line))
                    {
                        var tableDate = TryGetTableDate(line);
                    }                    
                }
            }

            return Constants.ErrorCodes.Success;
        }

        private bool IsCreateTableStatement(string line)
        {
            return line?.StartsWith("CREATE TABLE") ?? false;
        }

        private DateTime? TryGetTableDate(string line)
        {
            var parts = line.Split(' ');
            var dateStr = parts[2].Replace("`", string.Empty);
            if (DateTime.TryParse(dateStr, out DateTime date))
            {
                return date;
            }

            return null;
        }
    }
}