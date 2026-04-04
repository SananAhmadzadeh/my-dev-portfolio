using Entities.DTOs.StatisticsDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validators.Statistics
{
    public class UpdateStatisticsDtoValidator : AbstractValidator<UpdateStatisticsDto>
    {
        public UpdateStatisticsDtoValidator()
        {
            RuleFor(st => st.GraduatedsCount)
           .GreaterThan(0).WithMessage("GraduatedsCount is greater than 0.");


            RuleFor(st => st.CoursesCount)
           .GreaterThan(0).WithMessage("CoursesCount is greater than 0.");

            RuleFor(st => st.GraduatesWorkingCount)
           .GreaterThan(0).WithMessage("GraduatesWorkingCount is greater than 0.");

            RuleFor(st => st.CompaniesPartnerCount)
          .GreaterThan(0).WithMessage("CompaniesPartnerCount is greater than 0.");

        }
    }
}
