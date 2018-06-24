namespace FLDCLegacyDataMigrator.Services.Abstract
{
    using System;

    public interface ILoggingService
    {
        void LogDebug(string message);

        void LogError(string message);

        void LogException(Exception ex);

        void LogWarning(string message);
    }
}