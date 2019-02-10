using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterTypes
{
    public class ApplicationRegistry: StructureMap.Registry
    {
        public ApplicationRegistry()
        {
            For<ProductRepository>().Use<ProductRepository>().AlwaysUnique();
        }
    }
}
