namespace FLDCLegacyDataMigrator.Services.Concrete
{
    using System;

    using FLDCLegacyDataMigrator.Services.Abstract;

    public class MigratorProvider : IMigratorService
    {
        public int Execute(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            return 0;
        }
    }
}