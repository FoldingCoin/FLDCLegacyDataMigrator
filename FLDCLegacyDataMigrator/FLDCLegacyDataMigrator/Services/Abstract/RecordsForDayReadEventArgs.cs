namespace FLDCLegacyDataMigrator.Services.Abstract
{
    using System;
    using System.Collections.Generic;

    using FLDCLegacyDataMigrator.Entity;

    public class RecordsForDayReadEventArgs : EventArgs
    {
        public RecordsForDayReadEventArgs(IEnumerable<LegacyDataItem> records)
        {
            Records = records;
        }

        public IEnumerable<LegacyDataItem> Records { get; }
    }
}