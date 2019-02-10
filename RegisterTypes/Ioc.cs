using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using StructureMap;

namespace RegisterTypes
{
    public static class Ioc
    {
        private static Container _container;

        static Ioc()
        {
            _container = new Container();
        }

        public static void Configure()
        {
            ConfigureStructuremap();
        }

        public static T GetType<T>()
        {
            return _container.GetInstance<T>();
        }

        private static void ConfigureLogging(ILogger logger)
        {
            _container.Configure(x =>
            {
                x.For<ILogger>().Use(logger);
            });
        }

        private static void ConfigureStructuremap()
        {
            _container.Configure(x =>
            {
                x.AddRegistry(new DataRegistry());
                x.AddRegistry(new ApplicationRegistry());
            });
            _container.AssertConfigurationIsValid();
        }
    }
}
