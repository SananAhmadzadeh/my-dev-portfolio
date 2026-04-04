//using Business.TranslationValidators.BlogTranslations;
using Entities.DTOs.BlogDTOs;
using FluentValidation;

namespace Business.Validators.Blogs;

public class UpdateBlogDTOValidator : AbstractValidator<UpdateBlogDTO>
{
    public UpdateBlogDTOValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Description)
           .NotEmpty()
           .NotNull();
        //RuleForEach(x => x.Translations)
        //    .SetValidator(new UpdateBlogTranslationDTOValidator())
        //    .When(x => x.Translations != null);
    }
}
