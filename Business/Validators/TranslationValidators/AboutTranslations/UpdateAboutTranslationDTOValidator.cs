//using Entities.TranslationDTOs.AboutTranslationDTOs;
//using FluentValidation;

//namespace Business.TranslationValidators.AboutTranslations
//{
//    public class UpdateAboutTranslationDTOValidator : AbstractValidator<UpdateAboutTranslationDTO>
//    {
//        public UpdateAboutTranslationDTOValidator()
//        {
//            RuleFor(x => x.Title)
//                .MaximumLength(100).WithMessage("Başlıq maksimum 100 simvol ola bilər")
//                .When(x => x.Title != null);

//            RuleFor(x => x.Description)
//                .MaximumLength(500).WithMessage("Mövzu maksimum 500 simvol ola bilər")
//                .When(x => x.Description != null);
//        }
//    }
//}
