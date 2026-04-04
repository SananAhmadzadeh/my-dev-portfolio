using Entities.DTOs.SkillDTOs;
using FluentValidation;

namespace Business.Validators.Skills
{
    public class CreateSkillDtoValidator : AbstractValidator<CreateSkillDto>
    {
        public CreateSkillDtoValidator()
        {
            RuleFor(s => s.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);
        }
    }
}
