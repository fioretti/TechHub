using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHub.Lib.Core;

namespace TechHub.Lib.Model
{
    public interface IEntityRepository: IRepository<TechHub.Lib.Model.Entity>
    {
        IEnumerable<Entity> GetSpEntitiesByType(string type);
        ObjectResult<Entity> GetSpEntities();
    }
}
