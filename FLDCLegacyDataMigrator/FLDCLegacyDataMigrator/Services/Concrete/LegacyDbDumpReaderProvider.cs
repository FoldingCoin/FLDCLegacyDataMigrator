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

        public LegacyDbDumpReaderProvider(IFileSystemOperationsService fileSystemOperations, ILoggingService loggingService)
        {
            this.fileSystemOperations = fileSystemOperations;
            this.loggingService = loggingService;
        }

        public event EventHandler<RecordsForDayReadEventArgs> RecordsForDayRead;

        public int ReadData(string filename)
        {
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
                            var tableDate = TryGetTableDate(line);
                            if (tableDate != null)
                            {
                                if (currentTableDate != null && (tableDate.Value - currentTableDate.Value).Days != 0)
                                {
                                    if (recordsForDay.Any())
                                    {
                                        RecordsForDayRead?.Invoke(
                                            this,
                                            new RecordsForDayReadEventArgs(new List<LegacyDataItem>(recordsForDay)));
                                    }

                                    recordsForDay.Clear();
                                }

                                currentTableDate = tableDate;
                            }
                        }
                        else if (IsInsertRow(line))
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
                    }
                }

                if (recordsForDay.Any())
                {
                    RecordsForDayRead?.Invoke(
                        this,
                        new RecordsForDayReadEventArgs(new List<LegacyDataItem>(recordsForDay)));
                }
            }

            return Constants.ErrorCodes.Success;
        }

        private bool IsCreateTableStatement(string line)
        {
            return line.StartsWith("CREATE TABLE");
        }

        private bool IsInsertRow(string line)
        {
            return line.StartsWith("(") && (line.EndsWith("),") || line.EndsWith(");"));
        }

        private LegacyDataItem TryGetRow(string line, DateTime date)
        {
            try
            {
                var parts = line.Replace("(", string.Empty).Replace(")", string.Empty).Replace("'", string.Empty)
                    .Replace(";", string.Empty).Split(',', StringSplitOptions.RemoveEmptyEntries);
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