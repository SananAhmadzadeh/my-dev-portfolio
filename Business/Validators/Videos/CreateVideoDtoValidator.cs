using Entities.DTOs.VideoDTOs;
using FluentValidation;

namespace Business.Validators.Videos
{
    public class CreateVideoDtoValidator : AbstractValidator<CreateVideoDto>
    {
        public CreateVideoDtoValidator()
        {
            RuleFor(v => v.Title)
                .MinimumLength(5)
                .MaximumLength(200)
                .NotNull()
                .NotEmpty();

            RuleFor(v => v.VideoUrl)
                .NotNull()
                .NotEmpty();

            RuleFor(v => v.Description)
                .MinimumLength(5)
                .MaximumLength(1000)
                .NotNull()
                .NotEmpty();

            RuleFor(v => v.LessonId)
                .NotNull()
                .NotEmpty();

            RuleFor(v=> v.VideoOrder)
                .GreaterThanOrEqualTo(1)
                .NotNull()
                .NotEmpty();

            RuleFor(v=> v.Provider)
                .NotNull()
                .NotEmpty();
        }
    }
}
