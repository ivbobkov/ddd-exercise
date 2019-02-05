using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MoneyTracker.Infrastructure.Configuration;
using MoneyTracker.Infrastructure.Persistence;

namespace MoneyTracker.Infrastructure.Ioc
{
    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register<DbContextOptions>(cc =>
            {
                var connectionStrings = cc.Resolve<IOptions<ConnectionStrings>>();

                var optionsBuilder = new DbContextOptionsBuilder<MoneyTrackerDbContext>();
                optionsBuilder.UseSqlServer(connectionStrings.Value.MoneyTrackerConnection);

                return optionsBuilder.Options;
            }).InstancePerLifetimeScope();
        }
    }
}