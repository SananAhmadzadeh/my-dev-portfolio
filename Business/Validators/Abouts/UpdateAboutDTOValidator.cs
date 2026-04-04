//using Business.TranslationValidators.AboutTranslations;
using Entities.DTOs.AboutDTOs;
using FluentValidation;

namespace Business.Validators.Abouts
{
    public class UpdateAboutDTOValidator : AbstractValidator<UpdateAboutDTO>
    {
        public UpdateAboutDTOValidator()
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
            //RuleForEach(x => x.Translations)
            //    .SetValidator(new UpdateAboutTranslationDTOValidator())
            //    .When(x => x.Translations != null); 
        }
    }
}
