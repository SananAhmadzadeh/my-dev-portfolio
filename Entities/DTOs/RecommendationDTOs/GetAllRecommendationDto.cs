using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.Recommendations
{
    public class GetAllRecommendationDto : IDto
    {
        public Guid Id {  get; set; }

        public string IconUrl { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


    }
}
