namespace FLDCLegacyDataMigrator.Services.Concrete
{
    using FLDCLegacyDataMigrator.Services.Abstract;

    public class CommandLineArgumentsValidatorProvider : ICommandLineArgumentsValidatorService
    {
        private readonly IFileSystemOperationsService fileSystemOperations;     

        public CommandLineArgumentsValidatorProvider(
            IFileSystemOperationsService fileSystemOperations)
        {
            this.fileSystemOperations = fileSystemOperations;
        }

        public int Validate(string[] args)
        {
            if (args?.Length != 2)
            {
                return Constants.ErrorCodes.IncorrectArgumentCount;
            }

            var inputFilename = args[0]?.Trim();
            var outputDirectoryName = args[1]?.Trim();

            var result = ValidateInputFilename(inputFilename);
            if (result == Constants.ErrorCodes.Success)
            {
                result = ValidateOutputDirectoryName(outputDirectoryName);
            }

            return result;
        }

        private int ValidateOutputDirectoryName(string outputDirectoryName)
        {
            if (string.IsNullOrWhiteSpace(outputDirectoryName))
            {
                return Constants.ErrorCodes.InvalidOutputDirectoryName;
            }

            if (!fileSystemOperations.DirectoryExists(outputDirectoryName))
            {
                return Constants.ErrorCodes.OutputDirectoryDoesNotExist;
            }

            return Constants.ErrorCodes.Success;
        }

        private int ValidateInputFilename(string inputFilename)
        {
            if (string.IsNullOrWhiteSpace(inputFilename))
            {
                return Constants.ErrorCodes.InvalidInputFileName;
            }

            if (!fileSystemOperations.FileExists(inputFilename))
            {
                return Constants.ErrorCodes.InputFileDoesNotExist;
            }

            return Constants.ErrorCodes.Success;
        }
    }
}