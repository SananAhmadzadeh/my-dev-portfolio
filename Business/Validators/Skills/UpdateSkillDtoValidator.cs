using Entities.DTOs.SkillDTOs;
using FluentValidation;

namespace Business.Validators.Skills
{
    public class UpdateSkillDtoValidator : AbstractValidator<UpdateSkillDto>
    {
        public UpdateSkillDtoValidator()
        {
            RuleFor(s=> s.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);
        }
    }
}
