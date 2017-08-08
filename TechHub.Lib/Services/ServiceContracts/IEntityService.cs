using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHub.Lib.Model;
using TechHub.Lib.Services.Messages;

namespace TechHub.Lib.Services.ServiceContracts
{
    public interface IEntityService
    {

        EntityResponse GetSpEntities();
        EntityResponse GetSpEntitiesByType(string type);
        EntityResponse GetAll();
        EntityResponse Add(Entity entity);
        EntityResponse GetById(int? id);
        EntityResponse Update(Entity entity);
        EntityResponse Delete(int? id);
    }
}
