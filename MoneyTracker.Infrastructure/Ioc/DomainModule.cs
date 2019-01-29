using Autofac;
using MoneyTracker.Domain.SeedWork;
using MoneyTracker.Domain.WriteModel.BalanceAggregate;
using MoneyTracker.Infrastructure.Domain.WriteModel;
using MoneyTracker.Infrastructure.Persistence;

namespace MoneyTracker.Infrastructure.Ioc
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BalanceRepository>().As<IBalanceRepository>().InstancePerLifetimeScope();

            builder.RegisterType<MoneyTrackerDbContext>()
                .AsSelf().InstancePerLifetimeScope()
                .As<IUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}
