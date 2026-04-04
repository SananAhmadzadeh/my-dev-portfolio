using Core.Entities.Abstract;
//using Entities.TranslationDTOs.BlogTranslationDTOs;

namespace Entities.DTOs.BlogDTOs;

public class GetAllBlogDTO : IDto
{
    public Guid Id { get; set; }
    public Guid TeacherId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    //public List<GetBlogTranslationDTO> Translations { get; set; } = new();
}
