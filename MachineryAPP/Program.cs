using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Transactions;
using Autofac;
using static System.Console;

namespace MachineryAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }

        }
    }
}
