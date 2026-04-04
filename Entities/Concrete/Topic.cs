using Core.Entities.Abstract;
using Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Topic:BaseEntity, IEntity
    {
        public string Name { get; set; }
        public Guid LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}
