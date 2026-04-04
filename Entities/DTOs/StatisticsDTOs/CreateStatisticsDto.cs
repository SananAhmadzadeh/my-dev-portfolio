using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.StatisticsDTOs
{
    public class CreateStatisticsDto : IDto
    {
        public int GraduatedsCount { get; set; }
        public int CoursesCount { get; set; }
        public int GraduatesWorkingCount { get; set; }
        public int CompaniesPartnerCount { get; set; }
    }
}
