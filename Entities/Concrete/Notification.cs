using Core.Entities.Abstract;
using Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Notification:BaseEntity,IEntity
    {
        public string Title { get; set; }
        public string MessageTemplate { get; set; }
        public string RoleId { get; set; } 

    }
}
