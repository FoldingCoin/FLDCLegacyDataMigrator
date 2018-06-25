namespace FLDCLegacyDataMigrator.Services.Abstract
{
    using System;
    using System.Collections.Generic;

    using FLDCLegacyDataMigrator.Entity;

    public interface IStatsDataWriterService
    {
        int Write(IEnumerable<StatsDataItem> items, DateTime date, string filename);
    }
}