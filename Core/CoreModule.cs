using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    class CoreModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // builder.RegisterType<SomeUseCase>().As<ISomeUseCase>().InstancePerLifetimeScope();
        }
    }
}
