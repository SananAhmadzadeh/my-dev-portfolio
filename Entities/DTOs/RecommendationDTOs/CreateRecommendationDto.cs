using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.Recommendations
{
    public class CreateRecommendationDto : IDto
    {
        public IFormFile IconUrl { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
