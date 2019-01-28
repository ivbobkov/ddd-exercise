using Autofac;
using MoneyTracker.Domain.SeedWork;
using MoneyTracker.Domain.WriteModel.BalanceAggregate;
using MoneyTracker.Infrastructure.Persistence;
using MoneyTracker.Infrastructure.Repositories;

namespace MoneyTracker.Infrastructure.Ioc
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AccountRepository>().As<IBalanceRepository>().InstancePerLifetimeScope();

            builder.RegisterType<MoneyTrackerDbContext>()
                .AsSelf().InstancePerLifetimeScope()
                .As<IUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}
