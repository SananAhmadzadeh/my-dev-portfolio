using Core.Entities.Abstract;

namespace Entities.DTOs.AboutDTOs
{
    public class CreateAboutDTO:IDto
    {
        public int Year { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
