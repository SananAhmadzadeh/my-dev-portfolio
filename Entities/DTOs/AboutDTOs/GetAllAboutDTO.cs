using Core.Entities.Abstract;
//using Entities.TranslationDTOs.AboutTranslationDTOs;

namespace Entities.DTOs.AboutDTOs
{
    public class GetAllAboutDTO: IDto
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        //public List<GetAboutTranslationDTO> Translations { get; set; } = new();
    }
}
