namespace FLDCLegacyDataMigrator.Services.Concrete
{
    using System.Collections.Generic;

    using FLDCLegacyDataMigrator.Entity;
    using FLDCLegacyDataMigrator.Services.Abstract;

    public class DataMappingProvider : IDataMappingService
    {
        public IEnumerable<StatsDataItem> MapData(IEnumerable<LegacyDataItem> legacyData)
        {
            foreach (var legacyItem in legacyData)
            {
                yield return new StatsDataItem
                                 {
                                     Name = $"{legacyItem.Name}_{legacyItem.Token}_{legacyItem.Address}",
                                     NewCredit = legacyItem.TotalPoints, SumTotal = 0, Team = 0
                                 };
            }
        }
    }
}