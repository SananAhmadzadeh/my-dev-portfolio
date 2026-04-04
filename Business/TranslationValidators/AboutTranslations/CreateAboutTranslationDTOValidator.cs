//using Entities.TranslationDTOs.AboutTranslationDTOs;
//using FluentValidation;

//namespace Business.TranslationValidators.AboutTranslations
//{
//    public class CreateAboutTranslationDTOValidator : AbstractValidator<CreateAboutTranslationDTO>
//    {
//        public CreateAboutTranslationDTOValidator()
//        {
//            RuleFor(x => x.LanguageCode)
//                .NotEmpty().WithMessage("Dil kodu tələb olunur")
//                .MaximumLength(5).WithMessage("Dil kodu maksimum 5 simvol ola bilər");

//            RuleFor(x => x.Title)
//                .NotEmpty().WithMessage("Başlıq tələb olunur")
//                .MaximumLength(100).WithMessage("Başlıq maksimum 100 simvol ola bilər");

//            RuleFor(x => x.Description)
//                .NotEmpty().WithMessage("Mövzu tələb olunur")
//                .MaximumLength(500).WithMessage("Mövzu maksimum 500 simvol ola bilər");

//            //RuleFor(x => x.Slug)
//            //    .MaximumLength(300).WithMessage("Slug maksimum 300 simvol ola bilər")
//            //    .When(x => !string.IsNullOrEmpty(x.Slug));
//        }
//    }
//}
  