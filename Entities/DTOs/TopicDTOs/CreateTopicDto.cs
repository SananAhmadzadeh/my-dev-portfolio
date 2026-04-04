using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.TopicDTOs
{
    public class CreateTopicDto:IDto
    {
        public string Name { get; set; }
        public Guid LessonId { get; set; }
    }
}
