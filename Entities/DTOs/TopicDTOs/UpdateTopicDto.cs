using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.TopicDTOs
{
    public class UpdateTopicDto:IDto
    {
        public string Name { get; set; }
        public Guid LessonId { get; set; }
    }
}
