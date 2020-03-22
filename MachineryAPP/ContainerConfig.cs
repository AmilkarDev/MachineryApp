using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace MachineryAPP
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<OrderManager>().As<IOrderManager>();
            builder.RegisterType<MachineManager>().As<IMachineManager>();

            return builder.Build();
        }
    }
}
