using Core.Entities.Abstract;
using Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class UserQuention:BaseEntity, IEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
