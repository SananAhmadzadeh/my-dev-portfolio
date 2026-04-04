//using Business.TranslationValidators.AboutTranslations;
using Entities.DTOs.AboutDTOs;
using FluentValidation;

namespace Business.Validators.Abouts
{
    public class CreateAboutDTOValidator: AbstractValidator<CreateAboutDTO>
    {
        public CreateAboutDTOValidator()
        {
            RuleFor(x => x.Year)
                 .NotEmpty().WithMessage("Il tələb olunur")
                 .NotNull().WithMessage("Il boş ola bilməz");

            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Description)
               .NotEmpty()
               .NotNull();

            //RuleFor(x => x.Translations)
            //     .NotEmpty().WithMessage("Ən azı 1 translation olmalıdır");

            //RuleForEach(x => x.Translations)
            //     .SetValidator(new CreateAboutTranslationDTOValidator());
        }
    }
}
