using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.TopicDTOs
{
    public class GetTopicDto:IDto
    {
        public string Name { get; set; }
        public Guid LessonId { get; set; }
    }
}
