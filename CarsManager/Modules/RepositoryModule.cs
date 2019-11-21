using Autofac;

namespace Cars.Modules
{
    public class RepositoryModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           // builder.RegisterType<CarRepository>().As<ICarRepository>().InstancePerLifetimeScope();
        }
    }
}
