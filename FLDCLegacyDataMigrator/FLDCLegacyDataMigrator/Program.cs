namespace FLDCLegacyDataMigrator
{
    using System;

    using FLDCLegacyDataMigrator.Ioc;
    using FLDCLegacyDataMigrator.Services.Abstract;

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DependencyRegistration.Register();
                var migrator = WindsorContainer.Instance.Resolve<IMigratorService>();
                Environment.ExitCode = migrator.Execute(args);
                Console.WriteLine($"({Environment.ExitCode}) - {Constants.ErrorMessages.Get(Environment.ExitCode)}");
            }
            catch (Exception e)
            {
                Environment.ExitCode = -1;
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                WindsorContainer.Dispose();
            }
        }
    }
}