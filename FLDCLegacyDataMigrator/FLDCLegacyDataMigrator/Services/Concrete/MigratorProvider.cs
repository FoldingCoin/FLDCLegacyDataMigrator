namespace FLDCLegacyDataMigrator.Services.Concrete
{
    using System;

    using FLDCLegacyDataMigrator.Services.Abstract;

    public class MigratorProvider : IMigratorService
    {
        private readonly ILoggingService loggingService;

        public MigratorProvider(ILoggingService loggingService)
        {
            this.loggingService = loggingService;
        }

        public int Execute(string[] args)
        {
            loggingService.LogDebug("Begin Execution");
            Console.WriteLine("Hello World!");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            loggingService.LogDebug("End Execution");
            return 0;
        }
    }
}