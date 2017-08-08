using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace TechHub.Test
{
    public class BootStrapper
    {
        public static void ConfigureStructureMap()
        {
            // Initialize the registry
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry<TechHubRegistry>();

            });
        }
    }

    public class TechHubRegistry : Registry
    {
        public TechHubRegistry()
        {
            ForRequestedType<TechHub.Lib.Model.IEntityRepository>().TheDefaultIsConcreteType<TechHub.Lib.Repositories.EntityRepository>();
            ForRequestedType<TechHub.Lib.Services.ServiceContracts.IEntityService>().TheDefaultIsConcreteType<TechHub.Lib.Services.ServiceImplementations.EntityService>();
        }
    }
}
