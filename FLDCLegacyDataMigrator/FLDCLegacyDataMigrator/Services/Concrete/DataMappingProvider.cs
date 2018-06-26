namespace FLDCLegacyDataMigrator.Services.Concrete
{
    using System.Collections.Generic;

    using FLDCLegacyDataMigrator.Entity;
    using FLDCLegacyDataMigrator.Services.Abstract;

    public class DataMappingProvider : IDataMappingService
    {
        public IEnumerable<StatsDataItem> MapData(IEnumerable<LegacyDataItem> legacyData)
        {
            throw new System.NotImplementedException();
        }
    }
}