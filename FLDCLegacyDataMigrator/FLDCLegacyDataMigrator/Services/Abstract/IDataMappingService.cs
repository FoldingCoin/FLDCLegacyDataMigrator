namespace FLDCLegacyDataMigrator.Services.Abstract
{
    using System.Collections.Generic;

    using FLDCLegacyDataMigrator.Entity;

    public interface IDataMappingService
    {
        IEnumerable<StatsDataItem> MapData(IEnumerable<LegacyDataItem> legacyData);
    }
}