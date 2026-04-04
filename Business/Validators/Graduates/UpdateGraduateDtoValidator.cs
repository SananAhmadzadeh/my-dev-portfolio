using Entities.DTOs.GraduateDTOs;
using FluentValidation;

namespace Business.Validators.Graduates
{
    public class UpdateGraduateDtoValidator:AbstractValidator<UpdateGraduateDto>
    {
        public UpdateGraduateDtoValidator()
        {
            //RuleFor(g => g.FirstName)
            //    .NotEmpty()
            //    .NotNull()
            //    .MinimumLength(2)
            //    .MaximumLength(30);

            //RuleFor(g => g.LastName)
            //    .NotEmpty()
            //    .NotNull()
            //    .MinimumLength(2)
            //    .MaximumLength(50);
        }
    }
}
