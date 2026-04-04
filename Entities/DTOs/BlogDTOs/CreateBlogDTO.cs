using Core.Entities.Abstract;
//using Entities.TranslationDTOs.BlogTranslationDTOs;

namespace Entities.DTOs.BlogDTOs;

public class CreateBlogDTO : IDto
{
    public Guid TeacherId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    //public List<CreateBlogTranslationDTO> Translations { get; set; } = new();
}
