namespace Entities.Common
{
    public abstract class TranslatableEntity<TTranslation>: BaseEntity where TTranslation : TranslationBase
    {
        public List<TTranslation> Translations { get; set; }
            = new List<TTranslation>(); 
        public string DefaultLanguageCode { get; set; } = "az";
        public bool IsPublished { get; private set; }
        public DateTime? PublishedAt { get; private set; }
        public bool IsActive { get; set; } = true;
        public TTranslation? GetTranslation(string languageCode)
        {
            return Translations
                .FirstOrDefault(t => t.LanguageCode.ToLower() == languageCode.ToLower());
        }

        public void Publish()
        {
            IsPublished = true;
            PublishedAt = DateTime.UtcNow;
        }

        public void UnPublish()
        {
            IsPublished = false;
            PublishedAt = null;
        }
    }

}
