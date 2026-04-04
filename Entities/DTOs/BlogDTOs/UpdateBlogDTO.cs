using Core.Entities.Abstract;
//using Entities.TranslationDTOs.BlogTranslationDTOs;

namespace Entities.DTOs.BlogDTOs;

public class UpdateBlogDTO : IDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    //public List<UpdateBlogTranslationDTO>? Translations { get; set; }
}
