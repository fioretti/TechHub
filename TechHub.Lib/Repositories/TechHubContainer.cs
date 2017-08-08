using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechHub.Lib.Repositories
{
    public class TechHubContainer : ObjectContext
    {
        public TechHubContainer()
            : base("name=techhubEntities", "techhubEntities")
        {
        }

        private ObjectSet<TechHub.Lib.Model.Entity> _entities;
        public ObjectSet<TechHub.Lib.Model.Entity> Entities
        {
            get { return _entities ?? (_entities = CreateObjectSet<TechHub.Lib.Model.Entity>()); }
        }
    }
}
