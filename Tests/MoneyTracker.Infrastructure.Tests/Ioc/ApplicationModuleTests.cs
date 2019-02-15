using System.Net.NetworkInformation;
using Autofac;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using MoneyTracker.Application;
using MoneyTracker.Infrastructure.Ioc;
using MoneyTracker.Infrastructure.Persistence;
using NUnit.Framework;

namespace MoneyTracker.Infrastructure.Tests.Ioc
{
    [TestFixture]
    public class ApplicationModuleTests
    {
        private IContainer _container;

        [SetUp]
        public void SetUp()
        {
            var container = new ContainerBuilder();
            container.RegisterModule<ApplicationModule>();
            container.RegisterModule<DomainModule>();
            container.RegisterModule<PersistenceModule>();

            container.Register<DbContextOptions>(cc =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<MoneyTrackerDbContext>();
                optionsBuilder.UseInMemoryDatabase("In-Memory-Db");

                return optionsBuilder.Options;
            }).InstancePerLifetimeScope();

            _container = container.Build();
        }

        [Test]
        public void Register_VerifyRegisteredServices()
        {
            _container.Resolve<IBalanceService>().Should().NotBeNull();
            _container.Resolve<IPurchaseService>().Should().NotBeNull();
            _container.Resolve<ISalaryService>().Should().NotBeNull();
        }
    }
}
