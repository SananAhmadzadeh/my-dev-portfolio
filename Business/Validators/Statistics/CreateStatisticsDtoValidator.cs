using Entities.DTOs.GraduateDTOs;
using Entities.DTOs.StatisticsDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validators.Statistics
{
    public class CreateStatisticsDtoValidator : AbstractValidator<CreateStatisticsDto>
    {
        public CreateStatisticsDtoValidator()
        {
            RuleFor(st => st.GraduatedsCount)
           .GreaterThanOrEqualTo(0).WithMessage("GraduatedsCount is greater than or equal to 0.");


            RuleFor(st => st.CoursesCount)
           .GreaterThanOrEqualTo(0).WithMessage("CoursesCount is greater than or equal to 0.");

            RuleFor(st => st.GraduatesWorkingCount)
           .GreaterThanOrEqualTo(0).WithMessage("GraduatesWorkingCount is greater than or equal to 0.");

            RuleFor(st => st.CompaniesPartnerCount)
          .GreaterThanOrEqualTo(0).WithMessage("CompaniesPartnerCount is greater than or equal to 0.");

        }
    }
}
