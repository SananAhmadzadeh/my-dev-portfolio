using Entities.DTOs.Events;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validators.Events
{
    public class CreateEventValidatorDto : AbstractValidator<CreateEventDto>
    {
        public CreateEventValidatorDto()
        {
            RuleFor(e => e.Title)
               .NotEmpty()
               .NotNull()
               .MinimumLength(2)
               .MaximumLength(50);

            RuleFor(e => e.Description)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(500);

            RuleFor(e => e.Location)
                 .NotEmpty()
                 .NotNull()
                 .MinimumLength(2)
                 .MaximumLength(100);


           
        }
    }
}
