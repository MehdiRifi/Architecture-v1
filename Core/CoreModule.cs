using Autofac;

namespace Core
{
    class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // builder.RegisterType<SomeUseCase>().As<ISomeUseCase>().InstancePerLifetimeScope();
        }
    }
}
