//using Entities.TranslationDTOs.BlogTranslationDTOs;
//using FluentValidation;

//namespace Business.TranslationValidators.BlogTranslations
//{
//    public class UpdateBlogTranslationDTOValidator : AbstractValidator<UpdateBlogTranslationDTO>
//    {
//        public UpdateBlogTranslationDTOValidator()
//        {
//            RuleFor(x => x.LanguageCode)
//                .NotEmpty().WithMessage("Dil kodu tələb olunur")
//                .MaximumLength(5).WithMessage("Dil kodu maksimum 5 simvol ola bilər");

//            RuleFor(x => x.Title)
//                .MaximumLength(100).WithMessage("Başlıq maksimum 100 simvol ola bilər")
//                .When(x => x.Title != null);

//            RuleFor(x => x.Description)
//                .MaximumLength(500).WithMessage("Mövzu maksimum 500 simvol ola bilər")
//                .When(x => x.Description != null);

//            RuleFor(x => x.Slug)
//                .MaximumLength(300).WithMessage("Slug maksimum 300 simvol ola bilər")
//                .When(x => !string.IsNullOrEmpty(x.Slug));
//        }
//    }
//}
