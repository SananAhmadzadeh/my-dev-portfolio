//using Entities.TranslationDTOs.CourseTranslationDTOs;
//using FluentValidation;

//namespace Business.TranslationValidators.CourseTranslation
//{
//    public class CreateCourseTranslationDTOValidator : AbstractValidator<CreateCourseTranslationDTO>
//    {
//        public CreateCourseTranslationDTOValidator()
//        {
//            RuleFor(x => x.LanguageCode)
//              .NotEmpty().WithMessage("Dil kodu tələb olunur")
//              .MaximumLength(5).WithMessage("Dil kodu maksimum 5 simvol ola bilər");

//            RuleFor(x => x.Name)
//                .MaximumLength(100).WithMessage("Ad maksimum 100 simvol ola bilər")
//                .When(x => x.Name != null);

//            RuleFor(x => x.Description)
//                .MaximumLength(500).WithMessage("Açıqlama maksimum 500 simvol ola bilər")
//                .When(x => x.Description != null);

//            RuleFor(x => x.Slug)
//                .MaximumLength(300).WithMessage("Slug maksimum 300 simvol ola bilər")
//                .When(x => !string.IsNullOrEmpty(x.Slug));
//        }
//    }
//}
