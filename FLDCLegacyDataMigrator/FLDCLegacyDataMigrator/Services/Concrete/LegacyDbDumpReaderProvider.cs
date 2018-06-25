namespace FLDCLegacyDataMigrator.Services.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FLDCLegacyDataMigrator.Entity;
    using FLDCLegacyDataMigrator.Services.Abstract;

    public class LegacyDbDumpReaderProvider : ILegacyDbDumpReaderService
    {
        private readonly IFileSystemOperationsService fileSystemOperations;

        private readonly ILoggingService loggingService;

        private bool eventFired;

        public LegacyDbDumpReaderProvider(
            IFileSystemOperationsService fileSystemOperations,
            ILoggingService loggingService)
        {
            this.fileSystemOperations = fileSystemOperations;
            this.loggingService = loggingService;
        }

        public event EventHandler<RecordsForDayReadEventArgs> RecordsForDayRead;

        public int ReadData(string filename)
        {
            eventFired = false;
            using (var reader = fileSystemOperations.OpenFileStreamReader(filename))
            {
                DateTime? currentTableDate = null;
                var recordsForDay = new List<LegacyDataItem>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine()?.Trim();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        if (IsCreateTableStatement(line))
                        {
                            currentTableDate = ProcessCreateTable(line, currentTableDate, recordsForDay);
                        }
                        else if (IsInsertRow(line))
                        {
                            ProcessRowInsert(currentTableDate, line, recordsForDay);
                        }
                    }
                }

                FireEventForDay(recordsForDay);
            }

            if (eventFired)
            {
                return Constants.ErrorCodes.Success;
            }

            return Constants.ErrorCodes.EmptyInputFile;
        }

        private void FireEventForDay(List<LegacyDataItem> recordsForDay)
        {
            if (recordsForDay.Any())
            {
                RecordsForDayRead?.Invoke(
                    this,
                    new RecordsForDayReadEventArgs(new List<LegacyDataItem>(recordsForDay)));
                eventFired = true;
            }
        }

        private bool IsCreateTableStatement(string line)
        {
            return line.StartsWith("CREATE TABLE");
        }

        private bool IsInsertRow(string line)
        {
            return line.StartsWith("(") && (line.EndsWith("),") || line.EndsWith(");"));
        }

        private DateTime? ProcessCreateTable(
            string line,
            DateTime? currentTableDate,
            List<LegacyDataItem> recordsForDay)
        {
            var tableDate = TryGetTableDate(line);
            if (tableDate != null)
            {
                if (currentTableDate != null && (tableDate.Value - currentTableDate.Value).Days != 0)
                {
                    FireEventForDay(recordsForDay);
                    recordsForDay.Clear();
                }

                currentTableDate = tableDate;
            }

            return currentTableDate;
        }

        private void ProcessRowInsert(DateTime? currentTableDate, string line, List<LegacyDataItem> recordsForDay)
        {
            if (currentTableDate.HasValue)
            {
                LegacyDataItem readItem = TryGetRow(line, currentTableDate.Value);
                if (readItem != null)
                {
                    recordsForDay.Add(readItem);
                }
            }
        }

        private string[] SplitLineForDataRow(string line)
        {
            var parts = line.Replace("(", string.Empty).Replace(")", string.Empty).Replace("'", string.Empty)
                .Replace(";", string.Empty).Split(',', StringSplitOptions.RemoveEmptyEntries);
            return parts;
        }

        private LegacyDataItem TryGetRow(string line, DateTime date)
        {
            try
            {
                var parts = SplitLineForDataRow(line);
                var result = new LegacyDataItem();
                result.Id = long.Parse(parts[0].Trim());
                result.Name = parts[1].Trim();
                result.Token = parts[2].Trim();
                result.Address = parts[3].Trim();
                result.TotalPoints = long.Parse(parts[4].Trim());
                result.Date = date;
                return result;
            }
            catch (Exception)
            {
                loggingService.LogWarning($"Row could not be parsed: {line}");
                return null;
            }
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