using Autofac;
using Core.Interfaces.Repositories;
using Data.Repositories;

namespace Architecture.Data.Modules
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PersonRepository>().As<IPersonRepository>().InstancePerLifetimeScope();
        }
    }
}
