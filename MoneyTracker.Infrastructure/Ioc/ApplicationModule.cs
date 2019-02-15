using Autofac;
using MoneyTracker.Application;
using MoneyTracker.Application.Implementations;

namespace MoneyTracker.Infrastructure.Ioc
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BalanceService>().As<IBalanceService>().InstancePerLifetimeScope();
            builder.RegisterType<PurchaseService>().As<IPurchaseService>().InstancePerLifetimeScope();
            builder.RegisterType<SalaryService>().As<ISalaryService>().InstancePerLifetimeScope();
        }
    }
}