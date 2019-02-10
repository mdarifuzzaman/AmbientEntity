using Domain;
using Infrastructure;
using Infrastructure.Data;
using Mehdime.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterTypes
{
    public class DataRegistry : StructureMap.Registry
    {
        public DataRegistry()
        {
            For<ProductDbContext>().Use<ProductDbContext>().AlwaysUnique();

            For<IAmbientDbContextLocator>().Use<AmbientDbContextLocator>();

            For<IDbContextScopeFactory>().Use(new DbContextScopeFactory());

            For<IEntitySet<Product>>().Use<AmbientProductEntitySet<Product, ProductDbContext>>();
        }

    }
}
