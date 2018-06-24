namespace FLDCLegacyDataMigrator.Services.Concrete
{
    using System;

    using FLDCLegacyDataMigrator.Services.Abstract;

    public class MigratorProvider : IMigratorService
    {
        private readonly ICommandLineArgumentsValidatorService inputValidator;

        private readonly ILoggingService loggingService;

        public MigratorProvider(ILoggingService loggingService, ICommandLineArgumentsValidatorService inputValidator)
        {
            this.loggingService = loggingService;
            this.inputValidator = inputValidator;
        }

        public int Execute(string[] args)
        {
            loggingService.LogDebug("Begin Execution");

            var result = inputValidator.Validate(args);
            if (result == Constants.ErrorCodes.Success)
            {
                Console.WriteLine("Hello World!");
            }

            loggingService.LogDebug("End Execution");
            return result;
        }
    }
}