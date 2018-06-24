namespace FLDCLegacyDataMigrator.Services.Abstract
{
    public interface ICommandLineArgumentsValidatorService
    {
        int Validate(string[] args);
    }
}