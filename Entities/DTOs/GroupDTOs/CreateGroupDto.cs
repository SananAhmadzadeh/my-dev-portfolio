using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.GroupDTOs
{
    public class CreateGroupDto:IDto
    {
        public string Name { get; set; }
        public Guid? CourseId { get; set; }
        public Guid? TeacherId { get; set; }
    }
}
