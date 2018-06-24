namespace FLDCLegacyDataMigrator.Services.Concrete
{
    using System;

    using FLDCLegacyDataMigrator.Services.Abstract;

    public class ConsoleLoggingProvider : ILoggingService
    {
        private const string MessageTypeDebug = "DEBUG";

        private const string MessageTypeError = "ERROR";

        private const string MessageTypeWarning = "WARNING";

        private readonly IDateTimeService dateTimeService;

        public ConsoleLoggingProvider(IDateTimeService dateTimeService)
        {
            this.dateTimeService = dateTimeService;
        }

        public void LogDebug(string message)
        {
            WriteLineToConsole(MessageTypeDebug, message);
        }

        public void LogError(string message)
        {
            WriteLineToConsole(MessageTypeError, message);
        }

        public void LogException(Exception ex)
        {
            WriteLineToConsole(MessageTypeError, $"Exception:{Environment.NewLine}{ex}");
        }

        public void LogWarning(string message)
        {
            WriteLineToConsole(MessageTypeWarning, message);
        }

        private void WriteLineToConsole(string messageType, string message)
        {
            var timestamp = dateTimeService.DateTimeNow();
            Console.WriteLine($"[{timestamp}] [{messageType}] {message}");
        }
    }
}