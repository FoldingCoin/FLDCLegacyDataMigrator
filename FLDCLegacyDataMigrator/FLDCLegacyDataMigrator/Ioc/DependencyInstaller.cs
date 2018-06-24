﻿namespace FLDCLegacyDataMigrator.Ioc
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using FLDCLegacyDataMigrator.Services.Abstract;
    using FLDCLegacyDataMigrator.Services.Concrete;

    public class DependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IMigratorService>().ImplementedBy<MigratorProvider>().LifestyleTransient(),
                Component.For<ILoggingService>().ImplementedBy<ConsoleLoggingProvider>().LifestyleSingleton(),
                Component.For<IDateTimeService>().ImplementedBy<DateTimeProvider>().LifestyleSingleton());
        }
    }
}