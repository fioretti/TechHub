using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using StructureMap;
using TechHub.Lib.Services.Messages;
using TechHub.Lib.Services.ServiceContracts;

namespace TechHub.Test
{
    [TestFixture()]
    public class EntityTest
    {
        private IEntityService _entityService;
        private EntityResponse _entityResponse;

        [TestFixtureSetUp]
        public void InitializeTest()
        {
            BootStrapper.ConfigureStructureMap();
            _entityService = (IEntityService) ObjectFactory.GetInstance(typeof (IEntityService));
        }

        [TestFixtureTearDown]
        public void EndTest()
        {
            //shutdown
        }

        [Test()]
        public void GetEntities()
        {
            _entityResponse = _entityService.GetAll();

            Assert.AreEqual(6, _entityResponse.Entities.Count);
        }

        [Test()]
        public void GetStoredProcEntities()
        {
            _entityResponse = _entityService.GetSpEntities();

            Assert.AreEqual(6, _entityResponse.Entities.Count);
        }

        [Test()]
        public void GetStoredProcEntitiesByType()
        {
            _entityResponse = _entityService.GetSpEntitiesByType("Action");

            Assert.AreEqual(2, _entityResponse.Entities.Count);
        }
    }
}
