//using Business.TranslationValidators.BlogTranslations;
using Entities.DTOs.BlogDTOs;
using FluentValidation;

namespace Business.Validators.Blogs;

public class CreateBlogDTOValidator : AbstractValidator<CreateBlogDTO>
{
    public CreateBlogDTOValidator()
    {
        RuleFor(x => x.TeacherId)
            .NotNull();

        RuleFor(x => x.Title)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Description)
           .NotEmpty()
           .NotNull();
        //RuleFor(x => x.Translations)
        //     .NotEmpty().WithMessage("Ən azı 1 translation olmalıdır");

        //RuleForEach(x => x.Translations)
        //    .SetValidator(new CreateBlogTranslationDTOValidator());
    }
}
