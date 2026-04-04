using Entities.DTOs.Recommendations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validators.Recommendations
{
    public class UpdateRecommendationValidatorDto : AbstractValidator<UpdateRecommendationDto>
    {
        public UpdateRecommendationValidatorDto()
        {
            RuleFor(r => r.Name)
              .NotEmpty()
              .NotNull()
              .MinimumLength(2)
              .MaximumLength(100);


            RuleFor(r => r.Description)
                .MinimumLength(2)
                .MaximumLength(500);

            RuleFor(r => r.IconUrl)
                .NotEmpty()
                .NotNull();
        }
    }
}
