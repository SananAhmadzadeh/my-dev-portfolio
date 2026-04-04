//using Entities.TranslationDTOs.BlogTranslationDTOs;
//using FluentValidation;

//namespace Business.TranslationValidators.BlogTranslations
//{
//    public class CreateBlogTranslationDTOValidator : AbstractValidator<CreateBlogTranslationDTO>
//    {
//        public CreateBlogTranslationDTOValidator()
//        {
//            RuleFor(x => x.LanguageCode)
//               .NotEmpty().WithMessage("Dil kodu tələb olunur")
//               .MaximumLength(5).WithMessage("Dil kodu maksimum 5 simvol ola bilər");

//            RuleFor(x => x.Title)
//                .NotEmpty().WithMessage("Başlıq tələb olunur")
//                .MaximumLength(100).WithMessage("Başlıq maksimum 100 simvol ola bilər");

//            RuleFor(x => x.Description)
//                .NotEmpty().WithMessage("Mövzu tələb olunur")
//                .MaximumLength(500).WithMessage("Mövzu maksimum 500 simvol ola bilər");
//        }
//    }
//}
