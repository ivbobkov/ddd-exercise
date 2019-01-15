using Autofac;
using MoneyTracker.Domain.AggregatesModel.AccountAggregate;
using MoneyTracker.Domain.SeedWork;
using MoneyTracker.Infrastructure.Persistence;
using MoneyTracker.Infrastructure.Repositories;

namespace MoneyTracker.Infrastructure.Ioc
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AccountRepository>().As<IAccountRepository>().InstancePerLifetimeScope();

            builder.RegisterType<MoneyTrackerDbContext>()
                .AsSelf().InstancePerLifetimeScope()
                .As<IUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}
