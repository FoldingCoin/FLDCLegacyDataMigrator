namespace FLDCLegacyDataMigrator.Tests
{
    using FLDCLegacyDataMigrator.Services.Abstract;
    using FLDCLegacyDataMigrator.Services.Concrete;

    using NSubstitute;

    using NUnit.Framework;

    [TestFixture]
    public class MigratorProviderTests
    {
        private ILoggingService loggingServiceMock;

        private MigratorProvider systemUnderTest;

        private ICommandLineArgumentsValidatorService validatorMock;

        [Test]
        public void Execute_WhenInvoked_LogsBeginAndEnd()
        {
            systemUnderTest.Execute(new[] { "arg1", "arg2" });

            loggingServiceMock.Received(1).LogDebug("Begin Execution");
            loggingServiceMock.Received(1).LogDebug("End Execution");
        }

        [TestCase(Constants.ErrorCodes.Success)]
        [TestCase(Constants.ErrorCodes.InvalidInputFileName)]
        [TestCase(Constants.ErrorCodes.OutputDirectoryDoesNotExist)]
        public void Execute_WhenInvoked_ReturnsValidatorResult(int expectedCode)
        {
            var args = new[] { "arg1", "arg2" };
            validatorMock.Validate(args).Returns(expectedCode);

            var actual = systemUnderTest.Execute(args);

            Assert.That(actual, Is.EqualTo(expectedCode));
        }

        [Test]
        public void Execute_WhenInvoked_ValidatesArgs()
        {
            var args = new[] { "arg1", "arg2" };

            systemUnderTest.Execute(args);

            validatorMock.Received(1).Validate(args);
        }

        [SetUp]
        public void SetUp()
        {
            loggingServiceMock = Substitute.For<ILoggingService>();
            validatorMock = Substitute.For<ICommandLineArgumentsValidatorService>();
            systemUnderTest = new MigratorProvider(loggingServiceMock, validatorMock);
        }
    }
}