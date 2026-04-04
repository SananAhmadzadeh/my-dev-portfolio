using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.HomePageDTOs.PopularCoursesSection
{
    public class PopularCourseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int DurationInMonths { get; set; }
        public int StudentCount { get; set; }
        public double Rating { get; set; }
    }
}
