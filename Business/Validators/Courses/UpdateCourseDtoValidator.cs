//using Business.TranslationValidators.CourseTranslation;
using Entities.DTOs.CourseDTOs;
using FluentValidation;

namespace Business.Validators.Courses
{
    public class UpdateCourseDtoValidator:AbstractValidator<UpdateCourseDto>
    {
        public UpdateCourseDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Ad boş ola bilməz");

            RuleFor(x => x.Description)
                 .NotNull().WithMessage("Açıqlama boş ola bilməz");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Price 0-dan kiçik ola bilməz");

            RuleFor(x => x.Time)
                .GreaterThan(0).WithMessage("Time 0-dan böyük olmalıdır");

            //RuleFor(x => x.Translations)
            //      .NotEmpty().WithMessage("Ən azı 1 translation olmalıdır");

            //RuleForEach(x => x.Translations)
            //      .SetValidator(new UpdateCourseTranslationDTOValidator());
        }
    }
}
