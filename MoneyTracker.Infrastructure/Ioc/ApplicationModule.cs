using Autofac;
using MoneyTracker.Application;

namespace MoneyTracker.Infrastructure.Ioc
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AccountService>().As<IAccountService>().InstancePerLifetimeScope();
        }
    }
}