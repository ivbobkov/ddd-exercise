using Autofac;
using Microsoft.EntityFrameworkCore;
using MoneyTracker.Infrastructure.Persistence;

namespace MoneyTracker.Infrastructure.Ioc
{
    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register<DbContextOptions>(cc =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<MoneyTrackerDbContext>();
                optionsBuilder.UseInMemoryDatabase("Database-In-Memory");

                return optionsBuilder.Options;
            }).InstancePerLifetimeScope();
        }
    }
}