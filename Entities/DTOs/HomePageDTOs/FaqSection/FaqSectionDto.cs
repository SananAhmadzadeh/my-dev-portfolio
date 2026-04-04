namespace Entities.DTOs.HomePageDTOs.FaqSection
{
    public class FaqSectionDto
    {
        public string SectionTitle { get; set; }
        public string SectionDescription { get; set; }
        public List<FaqItemDto> Items { get; set; }
    }
}
