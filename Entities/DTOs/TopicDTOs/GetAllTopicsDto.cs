using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.TopicDTOs
{
    public class GetAllTopicsDto:IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid LessonId { get; set; }
    }
}
