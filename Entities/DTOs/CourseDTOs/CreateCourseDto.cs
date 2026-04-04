using Core.Entities.Abstract;
//using Entities.TranslationDTOs.CourseTranslationDTOs;
using Microsoft.AspNetCore.Http;

public class CreateCourseDto : IDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public IFormFile ImageUrl { get; set; }
    public decimal Price { get; set; } = 0;
    public int Time { get; set; }
    //public List<CreateCourseTranslationDTO> Translations { get; set; } = new();
}
