using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.HomePageDTOs.PopularCoursesSection
{
    public class PopularCoursesSectionDto
    {
        public string SectionTitle { get; set; }
        public string SectionDescription { get; set; }
        public List<PopularCourseDto> Courses { get; set; }
    }
}
