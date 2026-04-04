using Core.Entities.Abstract;
using Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Recommendation:BaseEntity, IEntity
    {
        public string IconUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
