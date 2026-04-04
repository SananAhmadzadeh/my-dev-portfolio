using Microsoft.Extensions.Localization;
using System.Globalization;
using System.Resources;

namespace Business.Utilities.Localization
{
    public class StringLocalizer<T> : IStringLocalizer<T>
    {
        private readonly ResourceManager _resourceManager;
        private readonly string _resourceBaseName;

        public StringLocalizer()
        {
            var type = typeof(T);
            _resourceBaseName = type.FullName; // Məs: "Business.Services.Concrete.AboutManager"
            _resourceManager = new ResourceManager(_resourceBaseName, type.Assembly);
        }

        // 1. Sadə indexer
        public LocalizedString this[string name]
        {
            get
            {
                var value = GetStringSafely(name);
                return new LocalizedString(name, value ?? name, resourceNotFound: value == null);
            }
        }

        // 2. Formatlı (parametrli) indexer
        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var format = GetStringSafely(name);
                var value = string.Format(CultureInfo.CurrentUICulture, format ?? name, arguments);
                return new LocalizedString(name, value, resourceNotFound: format == null);
            }
        }

        // 3. ƏSKİK HİSSƏ: Bütün resursları gətirmək üçün
        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            // Resurs faylındakı bütün key-ləri oxumaq məntiqi bura yazılır
            return _resourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true)
                ?.Cast<System.Collections.DictionaryEntry>()
                .Select(e => new LocalizedString(e.Key.ToString(), e.Value.ToString(), false))
                ?? Enumerable.Empty<LocalizedString>();
        }

        private string GetStringSafely(string name)
        {
            try
            {
                return _resourceManager.GetString(name, CultureInfo.CurrentUICulture);
            }
            catch (MissingManifestResourceException)
            {
                return null; // Resurs faylı fiziki olaraq yoxdursa xəta verməsin
            }
        }
    }
}
