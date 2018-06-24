namespace FLDCLegacyDataMigrator.Tests
{
    using FLDCLegacyDataMigrator;
    using FLDCLegacyDataMigrator.Services.Abstract;
    using FLDCLegacyDataMigrator.Services.Concrete;

    using NSubstitute;

    using NUnit.Framework;

    [TestFixture]
    public class CommandLineArgumentsValidatorProviderTests
    {
        private IFileSystemOperationsService fileSystemOperationsMock;

        private CommandLineArgumentsValidatorProvider systemUnderTest;

        [SetUp]
        public void SetUp()
        {
            fileSystemOperationsMock = Substitute.For<IFileSystemOperationsService>();
            systemUnderTest = new CommandLineArgumentsValidatorProvider(fileSystemOperationsMock);
        }

        [Test]
        public void Validate_WhenAllGood_ReturnsSuccess()
        {
            fileSystemOperationsMock.FileExists("arg1").Returns(true);
            fileSystemOperationsMock.DirectoryExists("arg2").Returns(true);

            Assert.That(systemUnderTest.Validate(new[] { "arg1", "arg2" }), Is.EqualTo(Constants.ErrorCodes.Success));
        }

        [Test]
        public void Validate_WhenOneArg_ReturnsExpectedErrorCode()
        {
            Assert.That(
                systemUnderTest.Validate(new[] { "arg1" }),
                Is.EqualTo(Constants.ErrorCodes.IncorrectArgumentCount));
        }

        [Test]
        public void Validate_WhenEmptyInputFilename_ReturnsExpectedErrorCode()
        {
            Assert.That(
                systemUnderTest.Validate(new[] { " ", "arg2" }),
                Is.EqualTo(Constants.ErrorCodes.InvalidInputFileName));
        }

        [Test]
        public void Validate_WhenEmptyOutputDirectoryName_ReturnsExpectedErrorCode()
        {
            fileSystemOperationsMock.FileExists("arg1").Returns(true);

            Assert.That(
                systemUnderTest.Validate(new[] { "arg1", " " }),
                Is.EqualTo(Constants.ErrorCodes.InvalidOutputDirectoryName));
        }

        [Test]
        public void Validate_WhenInputFileDoesNotExist_ReturnsExpectedErrorCode()
        {
            fileSystemOperationsMock.FileExists("arg1").Returns(false);

            Assert.That(
                systemUnderTest.Validate(new[] { "arg1", " " }),
                Is.EqualTo(Constants.ErrorCodes.InputFileDoesNotExist));
        }

        [Test]
        public void Validate_WhenOutputDirectoryDoesNotExist_ReturnsExpectedErrorCode()
        {
            fileSystemOperationsMock.FileExists("arg1").Returns(true);
            fileSystemOperationsMock.DirectoryExists("arg2").Returns(false);

            Assert.That(
                systemUnderTest.Validate(new[] { "arg1", "arg2" }),
                Is.EqualTo(Constants.ErrorCodes.OutputDirectoryDoesNotExist));
        }
    }
}