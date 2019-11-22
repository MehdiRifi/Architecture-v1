using Autofac;
using Core.Interfaces.Repositories;
using Data.Repositories;

namespace CarsManager.Data.Modules
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarRepository>().As<ICarRepository>().InstancePerLifetimeScope();
        }
    }
}
