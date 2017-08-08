using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHub.Lib.Core;
using TechHub.Lib.Model;
using System.Data.SqlClient;

namespace TechHub.Lib.Repositories
{
    public class EntityRepository : BaseRepository<Entity>, IEntityRepository
    {
        public IEnumerable<Entity> GetSpEntitiesByType(string type)
        {
            var cmdText = "exec EntitiesByType @type_param";
            var @params = new[]{
                new SqlParameter("type_param", type)
            };

            var result = _context.ExecuteStoreQuery<Entity>(cmdText, @params);
            return result;
        }

        public ObjectResult<Entity> GetSpEntities()
        {
            var result = _context.ExecuteStoreQuery<Entity>("GetEntities");
            return result;
        }
    }
}