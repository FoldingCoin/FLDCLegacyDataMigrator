namespace FLDCLegacyDataMigrator.Services.Concrete
{
    using System;

    using FLDCLegacyDataMigrator.Services.Abstract;

    public class DateTimeProvider : IDateTimeService
    {
        public DateTime DateTimeNow()
        {
            return DateTime.UtcNow;
        }
    }
}