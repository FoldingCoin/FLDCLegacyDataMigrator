namespace FLDCLegacyDataMigrator.Entity
{
    using System;

    public class LegacyDataItem
    {
        public string Address { get; set; }

        public DateTime Date { get; set; }

        public long Id { get; set; }

        public string Name { get; set; }

        public string Token { get; set; }

        public long TotalPoints { get; set; }
    }
}