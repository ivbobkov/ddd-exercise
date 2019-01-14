using Autofac;
using MoneyTracker.Domain.Aggregates.AccountAggregate;
using MoneyTracker.Infrastructure.Domain.AccountAggregate;

namespace MoneyTracker.Infrastructure.Ioc
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AccountRepository>().As<IAccountRepository>().InstancePerLifetimeScope();
        }
    }
}
