using Entities.DTOs.Events;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validators.Events
{
    public class UpdateEventValidatorDto : AbstractValidator<UpdateEventDto>
    {
        public UpdateEventValidatorDto()
        {
            RuleFor(e => e.Title)
              .MaximumLength(50);

            RuleFor(e => e.Description)
               .MaximumLength(500);

            RuleFor(e => e.Location)
               .MaximumLength(100);
        }
    }
}
