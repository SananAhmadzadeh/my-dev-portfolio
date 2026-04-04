namespace Entities.Common
{
    public abstract class TranslationBase : BaseEntity
    {
        public string LanguageCode { get; set; } = null!;
        public string? Slug { get; set; }
    }
}
