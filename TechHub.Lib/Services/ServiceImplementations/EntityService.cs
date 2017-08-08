using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHub.Lib.Core;
using TechHub.Lib.Model;
using TechHub.Lib.Services.Messages;
using TechHub.Lib.Services.ServiceContracts;

namespace TechHub.Lib.Services.ServiceImplementations
{
    public class EntityService : IEntityService
    {
        private readonly IEntityRepository _entityRepository;
        private EntityResponse _response;

        public EntityService(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository;
            _response = new EntityResponse();
        }

        public EntityResponse GetSpEntities()
        {
             _response.Entities = _entityRepository.GetSpEntities().ToList();
            return _response;
        }
        public EntityResponse GetSpEntitiesByType(string type)
        {
            _response.Entities = _entityRepository.GetSpEntitiesByType(type).ToList();
            return _response;
        }
        public EntityResponse GetAll()
        {
            _response.Entities = _entityRepository.GetAll().ToList();
            return _response;
        }

        public EntityResponse GetById(int? id)
        {
            if (id != null)
            {
                var entity = _entityRepository.Single(m => m.Id == id);
                if (entity == null)
                {
                    _response.Message = string.Format("No record can be found with the ID of '{0}'.", id);
                    _response.Success = false;
                }
                else
                {
                    _response.Entity = entity;
                    _response.Success = true;
                }
            }
            else
            {
                _response.Message = string.Format("ID is invalid.");
                _response.Success = false;
            }

            return _response;
        }

        public EntityResponse Add(Entity entity)
        {
            if (entity.GetBrokenRules().Count == 0)
            {
                _entityRepository.Add(entity);
                _entityRepository.SaveChanges();
                _response.Success = true;
            }
            else
            {
                _response.Success = false;
                _response.Message = ErrorHelper.GetBrokenRulesToStringFor(entity.GetBrokenRules());
            }

            return _response;
        }


        public EntityResponse Update(Entity entity)
        {
            if (entity.GetBrokenRules().Count == 0)
            {
                _entityRepository.Update(entity);
                _response.Success = true;
            }
            else
            {
                _response.Success = false;
                _response.Message = ErrorHelper.GetBrokenRulesToStringFor(entity.GetBrokenRules());
            }

            return _response;
        }


        public EntityResponse Delete(int? id)
        {
            if (id != null)
            {
                var entity = _entityRepository.Single(m => m.Id == id);
                if (entity != null)
                {
                    _entityRepository.Delete(entity);
                    _entityRepository.SaveChanges();
                    _response.Success = true;
                }
                else
                {
                    _response.Message = string.Format("ID is invalid.");
                    _response.Success = false;
                }
            }
            else
            {
                _response.Message = string.Format("ID is invalid.");
                _response.Success = false;
            }

            return _response;
        }
    }
}
