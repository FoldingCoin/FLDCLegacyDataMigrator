namespace FLDCLegacyDataMigrator
{
    public static class Constants
    {
        public static class ErrorCodes
        {
            public const int Success = 0;

            public const int IncorrectArgumentCount = 1;

            public const int InvalidInputFileName = 2;

            public const int InputFileDoesNotExist = 3;

            public const int InvalidOutputDirectoryName = 4;

            public const int OutputDirectoryDoesNotExist = 5;
        }

        public static class ErrorMessages
        {
            public static string Get(int errorCode)
            {
                switch (errorCode)
                {
                    case ErrorCodes.Success:
                        return "Success";
                    case ErrorCodes.IncorrectArgumentCount:
                        return "This program requires two arguments: the input file name, and the output directory name.";
                    case ErrorCodes.InvalidInputFileName:
                        return "The specified input filename is invalid.";
                    case ErrorCodes.InputFileDoesNotExist:
                        return "The specified input file does not exist.";
                    case ErrorCodes.InvalidOutputDirectoryName:
                        return "The specified output directory name is invalid.";
                    case ErrorCodes.OutputDirectoryDoesNotExist:
                        return "The specified output directory does not exist.";
                    default:
                        return "Unknown error.";
                }
            }
        }
    }
}