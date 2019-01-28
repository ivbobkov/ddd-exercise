using Autofac;
using MoneyTracker.Application;

namespace MoneyTracker.Infrastructure.Ioc
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BalanceService>().As<IBalanceService>().InstancePerLifetimeScope();
        }
    }
}