using Entities.DTOs.VacancyDTOs;
using FluentValidation;

namespace Business.Validators.Vacancies
{
    public class CreateVacancyDtoValidator : AbstractValidator<CreateVacancyDto>
    {
        public CreateVacancyDtoValidator()
        {
            RuleFor(v=> v.Title)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100);

            RuleFor(v => v.Category)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100);

            RuleFor(v => v.Location)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100);

            RuleFor(v => v.EmploymentType)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100);

            RuleFor(v => v.SalaryMin)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(1);

            RuleFor(v => v.SalaryMax)
               .NotNull()
               .NotEmpty()
               .GreaterThanOrEqualTo(1);

            RuleFor(v => v.Currency)
               .NotNull()
               .NotEmpty()
               .MinimumLength(2)
               .MaximumLength(10);
        }
    }
}
