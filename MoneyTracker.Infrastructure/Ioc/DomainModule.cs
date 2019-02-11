using Autofac;
using MoneyTracker.Domain;
using MoneyTracker.Domain.ReadModel;
using MoneyTracker.Domain.WriteModel.BalanceAggregate;
using MoneyTracker.Domain.WriteModel.PurchaseAggregate;
using MoneyTracker.Domain.WriteModel.SalaryAggregate;
using MoneyTracker.Infrastructure.Domain;
using MoneyTracker.Infrastructure.Domain.ReadModel;
using MoneyTracker.Infrastructure.Domain.WriteModel;
using MoneyTracker.Infrastructure.Persistence;

namespace MoneyTracker.Infrastructure.Ioc
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BalanceRepository>().As<IBalanceRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PurchaseRepository>().As<IPurchaseRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SalaryRepository>().As<ISalaryRepository>().InstancePerLifetimeScope();

            builder.RegisterType<MoneyTrackerDbContext>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterType<ProvideBalanceDetails>().As<IProvideBalanceDetails>().InstancePerLifetimeScope();
            builder.RegisterType<ProvideCurrency>().As<IProvideCurrency>().InstancePerLifetimeScope();
        }
    }
}
