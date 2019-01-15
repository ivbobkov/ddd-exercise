using Autofac;
using MoneyTracker.Domain.AggregatesModel.AccountAggregate;
using MoneyTracker.Domain.QueriesModel;
using MoneyTracker.Domain.SeedWork;
using MoneyTracker.Infrastructure.Domain.AccountAggregate;
using MoneyTracker.Infrastructure.Domain.Queries;
using MoneyTracker.Infrastructure.Persistence;

namespace MoneyTracker.Infrastructure.Ioc
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AccountRepository>().As<IAccountRepository>().InstancePerLifetimeScope();
            builder.RegisterType<AccountProvider>().As<IAccountProvider>().InstancePerLifetimeScope();

            builder.RegisterType<MoneyTrackerDbContext>()
                .AsSelf().InstancePerLifetimeScope()
                .As<IUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}
