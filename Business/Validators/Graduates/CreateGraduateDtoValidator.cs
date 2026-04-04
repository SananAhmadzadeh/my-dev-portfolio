using Entities.DTOs.GraduateDTOs;
using FluentValidation;


namespace Business.Validators.Graduates
{
    public class CreateGraduateDtoValidator : AbstractValidator<CreateGraduateDto>
    {
        public CreateGraduateDtoValidator()
        {
            RuleFor(g => g.FirstName)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(30);

            RuleFor(g => g.LastName)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(50);

            RuleFor(g => g.Position)
                 .NotEmpty()
                 .NotNull()
                 .MinimumLength(2)
                 .MaximumLength(30);

            RuleFor(g => g.Company)
                .MinimumLength(2)
                .MaximumLength(500);

            RuleFor(g => g.ProfileImageUrl)
                .NotEmpty()
                .NotNull();
        }
    }
}
