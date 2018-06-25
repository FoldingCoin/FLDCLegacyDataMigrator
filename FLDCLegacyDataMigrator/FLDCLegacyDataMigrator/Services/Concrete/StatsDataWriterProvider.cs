namespace FLDCLegacyDataMigrator.Services.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using FLDCLegacyDataMigrator.Entity;
    using FLDCLegacyDataMigrator.Services.Abstract;

    public class StatsDataWriterProvider : IStatsDataWriterService
    {
        private readonly IFileSystemOperationsService fileSystemOperations;

        public StatsDataWriterProvider(IFileSystemOperationsService fileSystemOperations)
        {
            this.fileSystemOperations = fileSystemOperations;
        }

        public int Write(IEnumerable<StatsDataItem> items, DateTime date, string filename)
        {
            using (var writer = fileSystemOperations.OpenFileStreamWriter(filename))
            {
                WriteDateHeader(date, writer);
                WriteColumnHeader(writer);
                WriteItems(items, writer);
            }

            return Constants.ErrorCodes.Success;
        }

        private void WriteColumnHeader(StreamWriter writer)
        {
            var columnHeader = "name\tnewcredit\tsum(total)\tteam";
            WriteLine(columnHeader, writer);
        }

        private void WriteDateHeader(DateTime date, StreamWriter writer)
        {
            var dateHeader = date.ToString("ddd MMM dd 00:00:00 PST yyyy");
            WriteLine(dateHeader, writer);
        }

        private void WriteItem(StatsDataItem item, StreamWriter writer)
        {
            var line = $"{item.Name}\t{item.SumTotal}\t{item.NewCredit}\t{item.Team}";
            WriteLine(line, writer);
        }

        private void WriteItems(IEnumerable<StatsDataItem> items, StreamWriter writer)
        {
            foreach (var item in items)
            {
                WriteItem(item, writer);
            }
        }

        private void WriteLine(string text, StreamWriter writer)
        {
            writer.Write($"{text}\n");
        }
    }
}