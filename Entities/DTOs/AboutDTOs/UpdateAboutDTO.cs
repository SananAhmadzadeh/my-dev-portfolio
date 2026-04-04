using Core.Entities.Abstract;
//using Entities.TranslationDTOs.AboutTranslationDTOs;

namespace Entities.DTOs.AboutDTOs
{
    public class UpdateAboutDTO:IDto
    {
        public int Year { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        //public List<UpdateAboutTranslationDTO>? Translations { get; set; } 
    }
}
