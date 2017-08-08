using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHub.Lib.Model;

namespace TechHub.Lib.Services.Messages
{
    public class EntityResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public Entity Entity { get; set; }
        public List<Entity> Entities { get; set; }
    }
}
